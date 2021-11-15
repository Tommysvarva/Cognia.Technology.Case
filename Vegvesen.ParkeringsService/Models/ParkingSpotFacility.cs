using System;
using System.Collections.Generic;

#nullable disable

namespace Vegvesen.ParkeringsService.Models
{
    public partial class ParkingSpotFacility
    {
        public int Id { get; set; }
        public int FacilityId { get; set; }
        public int SpotId { get; set; }

        public virtual ParkingFacility Facility { get; set; }
        public virtual ParkingSpot Spot { get; set; }
    }
}
