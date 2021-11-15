using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vegvesen.ParkeringsService.Services
{
    public interface IVegvesenParkingSpots
    {
        Task<bool> RunImportsAsync();
    }
}
