using System;
using System.Collections.Generic;

#nullable disable

namespace Vegvesen.ParkeringsService.Models
{
    public partial class ParkingProviderSpot
    {
        public ParkingProviderSpot()
        {

        }
        public int Id { get; set; }
        public int SpotId { get; set; }
        public int ProviderId { get; set; }

        public virtual ParkingProvider Provider { get; set; }
        public virtual ParkingSpot Spot { get; set; }
    }
}
