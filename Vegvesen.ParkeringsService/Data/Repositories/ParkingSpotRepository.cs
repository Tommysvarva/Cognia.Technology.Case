using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegvesen.ParkeringsService.Models;

namespace Vegvesen.ParkeringsService.Data
{
    public class ParkingSpotRepository : IParkingSpotRepository
    {
        private readonly cognia_technology_caseContext _context;

        public ParkingSpotRepository(cognia_technology_caseContext context)
        {
            _context = context;
        }
        public void CreateParkingSpot(ParkingSpot parkingSpot)
        {
            if (parkingSpot == null)
            {
                throw new ArgumentNullException(nameof(parkingSpot));
            }

            _context.ParkingSpots.Add(parkingSpot);

        }

        public IEnumerable<ParkingSpot> GetAllParkingSpots()
        {
            return _context.ParkingSpots.ToList();
        }

        //public IEnumerable<ParkingSpot> GetAllParkingSpotsByFacilities(int facilityId1, int facilityId2)
        //{
        //    var parkingSpotFacilities = _context.ParkingSpotFacilities.Where(x => x.FacilityId == facilityId1 || x.FacilityId == facilityId2).ToList();

        //    var matchingSpots = new List<ParkingSpot>();
        //    foreach (var facilitySpot in parkingSpotFacilities)
        //    {
        //        var spotFacilties = parkingSpotFacilities.Where(x => x.SpotId == facilitySpot.SpotId);
        //        if (spotFacilties.Count() > 1)
        //        {
        //            var spot = GetParkingSpot(facilitySpot.SpotId);
        //            matchingSpots.Add(spot);
        //        }
        //    }
        //    matchingSpots = matchingSpots.Distinct().ToList();
        //    return matchingSpots;
        //}
        public IEnumerable<ParkingSpot> GetAllParkingSpotsByFacilities(List<int> facilityIds)
        {
            var parkingSpots = _context.ParkingSpots;
            var spotFacilities = _context.ParkingSpotFacilities
                .Where(x => facilityIds
                .Contains(x.FacilityId))
                .Include(x => x.Spot).ToList()
                .GroupBy(x => x.Spot).ToList();

            var matchingSpots = new List<ParkingSpot>();
            foreach (var spot in spotFacilities)
            {
                if(spot.Count() == facilityIds.Count())
                {
                    matchingSpots.Add(spot.Key);
                }
            }

            return matchingSpots;
           
        }

        public ParkingSpot GetParkingSpot(int id)
        {
            return _context.ParkingSpots.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
