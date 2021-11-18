using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Vegvesen.ParkeringsService.Data;
using Vegvesen.ParkeringsService.Models;
using Vegvesen.ParkeringsService.Services;

namespace Vegvesen.ParkeringsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VegvesenParkingSpotsController : ControllerBase
    {
        private readonly IVegvesenParkingSpots _service;
        private readonly ILogger _logger;
        private readonly IParkingSpotRepository _parkingSpotRepository;
        public VegvesenParkingSpotsController(IVegvesenParkingSpots service, ILogger logger,
            IParkingSpotRepository parkingSpotRepository
            )
        {
            _service = service;
            _logger = logger;
            _parkingSpotRepository = parkingSpotRepository;
        }
      
        [HttpPost]
        [Route("RunImportAsync")]
        public async Task<ActionResult> RunImportAsync()
        {
            try
            {
                //_logger.Information($"Exce RunImportAsync at VegvesenParkingSpotsController");
                var succes = await _service.RunImportsAsync();
                //_logger.Information($"Completed method: RunImportAsync at VegvesenParkingSpotsController.");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Something went wrong while running method: RunVegvesenParkingspotsImport at VegvesenParkingSpotsController");
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("parkingspots/get")]
        public  IActionResult GetParkingSpots([FromQuery]List<int> facilityIds)
         {
            var request = Request.Headers;
            try
            {
                _logger.Information($"GET Request starting GetParkingSpots({facilityIds})");
                var parkingSpots = _parkingSpotRepository.GetAllParkingSpotsByFacilities(facilityIds);

                if(parkingSpots.Count() < 1)
                {
                    return NotFound();
                }

                _logger.Information($"GET Request complete GetParkingSpots({facilityIds})");
                return Ok(parkingSpots);
            }
            catch(Exception ex)
            {
                _logger.Error(ex, $"GET Reques failed at GetParkingSpots{facilityIds}");
                return new StatusCodeResult(500);
            }
        }
    }
}
