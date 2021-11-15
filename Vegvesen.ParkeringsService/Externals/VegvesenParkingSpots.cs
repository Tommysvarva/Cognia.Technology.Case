using AutoMapper;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Vegvesen.ParkeringsService.Data;
using Vegvesen.ParkeringsService.Models;

namespace Vegvesen.ParkeringsService.Services
{
    public class VegvesenParkingSpots : IVegvesenParkingSpots
    {
        private readonly IConfiguration _config;
        private readonly IParkingProviderRepository _parkingProviderRepository;
        private readonly IParkingProviderSpotRepository _parkingProviderSpotRepository;
        private readonly IParkingSpotRepository _parkingSpotRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public VegvesenParkingSpots(IConfiguration config, IParkingProviderRepository parkingProviderRepository, IParkingProviderSpotRepository parkingProviderSpotRepository, IParkingSpotRepository parkingSpotRepository, IMapper mapper, ILogger logger)
        {
            _config = config;
            _parkingProviderRepository = parkingProviderRepository;
            _parkingProviderSpotRepository = parkingProviderSpotRepository;
            _parkingSpotRepository = parkingSpotRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> RunImportsAsync()
        {
            var parkingSpotsImport = await RunParkingSpotsImport();
            var parkingProvidersImport = await RunParkingProvidersImport();

            foreach (var spot in parkingSpotsImport)
            {
                _parkingSpotRepository.CreateParkingSpot(spot);
                _parkingSpotRepository.SaveChanges();
            }

            foreach (var provider in parkingProvidersImport)
            {
                _parkingProviderRepository.CreateProvider(provider);
                _parkingProviderRepository.SaveChanges();
            }

            MapParkingProviderSpots();

            return true;
        }

        private void MapParkingProviderSpots()
        {
            var parkingSpots = _parkingSpotRepository.GetAllParkingSpots();
            var parkingProviders = _parkingProviderRepository.GetAllProviders();
            foreach (var provider in parkingProviders)
            {
                var parkingProviderSpots = parkingSpots.Where(x => x.ParkeringstilbyderNavn == provider.Navn);
                foreach (var providerSpot in parkingProviderSpots)
                {
                    var parkingProviderSpot = new ParkingProviderSpot();
                    parkingProviderSpot.ProviderId = provider.Id;
                    parkingProviderSpot.SpotId = providerSpot.Id;
                    _parkingProviderSpotRepository.CreateProviderSpot(parkingProviderSpot);
                    _parkingProviderSpotRepository.SaveChanges();
                }
            }
        }

        private async Task<List<ParkingSpot>> RunParkingSpotsImport()
        {
            var client = new HttpClient();
            var requestUrl = _config.GetSection("ParkingspotsUrl").Value;
            try
            {
                var result = await client.GetStringAsync(requestUrl);
                var responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingSpotResponse>>(result);
                var model = _mapper.Map<List<ParkingSpot>>(responseModel);
                return model;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Something went wrong while fetching data from: {requestUrl}");
            }
            return null;
        }

        private async Task<List<ParkingProvider>> RunParkingProvidersImport()
        {
            var client = new HttpClient();
            var requestUrl = _config.GetSection("ParkingProvidersUrl").Value;
            try
            {
                var result = await client.GetStringAsync(requestUrl);
                var responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ParkingProvider>>(result);
                var model = _mapper.Map<List<ParkingProvider>>(responseModel);
                return model;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Something went wrong while fetching data from: {requestUrl}");
            }
            return null;
        }
    }
}
