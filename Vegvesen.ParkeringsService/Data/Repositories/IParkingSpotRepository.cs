using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegvesen.ParkeringsService.Models;

namespace Vegvesen.ParkeringsService.Data
{
    public interface IParkingSpotRepository
    {
        bool SaveChanges();
        void CreateParkingSpot(ParkingSpot parkingSpot);
        IEnumerable<ParkingSpot> GetAllParkingSpots();
        IEnumerable<ParkingSpot> GetAllParkingSpotsByFacilities(int facilityId1, int facilityId2);
        ParkingSpot GetParkingSpot(int id);
    }
}
