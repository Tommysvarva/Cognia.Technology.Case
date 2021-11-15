using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegvesen.ParkeringsService.Models;

namespace Vegvesen.ParkeringsService.Data
{
    public class ParkingProviderRepository : IParkingProviderRepository
    {

        private readonly cognia_technology_caseContext _context;

        public ParkingProviderRepository(cognia_technology_caseContext context)
        {
            _context = context;
        }
        public void CreateProvider(ParkingProvider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }

            _context.ParkingProviders.Add(provider);
        }

        public IEnumerable<ParkingProvider> GetAllProviders()
        {
            return _context.ParkingProviders.ToList();
        }
        public IEnumerable<ParkingProvider> GetAllProvidersAsNoTracking()
        {
            return _context.ParkingProviders.AsNoTracking().ToList();
        }

        public ParkingProvider GetProvider(int id)
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
