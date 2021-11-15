using AutoMapper;
using System.Collections.Generic;
using Vegvesen.ParkeringsService.Models;

namespace Vegvesen.ParkeringsService.Profiles
{
    public class ParkingServiceProfile : Profile
    {
        public ParkingServiceProfile()
        {
            CreateMap<ParkingSpotResponse, ParkingSpot>();
            CreateMap<ParkingProviderResponse, ParkingProvider>();
        }
    }
}
