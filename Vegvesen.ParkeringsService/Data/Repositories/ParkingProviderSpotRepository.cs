using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegvesen.ParkeringsService.Models;

namespace Vegvesen.ParkeringsService.Data
{
    public class ParkingProviderSpotRepository : IParkingProviderSpotRepository
    {
        private readonly cognia_technology_caseContext _context;
        public ParkingProviderSpotRepository(cognia_technology_caseContext context)
        {
            _context = context;
        }
        public void CreateProviderSpot(ParkingProviderSpot provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            _context.ParkingProviderSpots.Add(provider);
        }

        public IEnumerable<ParkingProviderSpot> GetAllProviderSpots()
        {
            return _context.ParkingProviderSpots.ToList();
        }

        public ParkingProviderSpot GetProviderSpot(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
