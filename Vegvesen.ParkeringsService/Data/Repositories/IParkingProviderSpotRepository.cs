using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vegvesen.ParkeringsService.Models;

namespace Vegvesen.ParkeringsService.Data
{
    public interface IParkingProviderSpotRepository
    {
        bool SaveChanges();
        void CreateProviderSpot(ParkingProviderSpot provider);
        IEnumerable<ParkingProviderSpot> GetAllProviderSpots();
        ParkingProviderSpot GetProviderSpot(int id);
    }
}
