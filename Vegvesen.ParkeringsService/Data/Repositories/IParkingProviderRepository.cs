using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegvesen.ParkeringsService.Models;

namespace Vegvesen.ParkeringsService.Data
{
    public interface IParkingProviderRepository
    {
        bool SaveChanges();
        void CreateProvider(ParkingProvider provider);
        IEnumerable<ParkingProvider> GetAllProviders();
        IEnumerable<ParkingProvider> GetAllProvidersAsNoTracking();
        ParkingProvider GetProvider(int id);
    }
}
