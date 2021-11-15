using System;
using System.Collections.Generic;

#nullable disable

namespace Vegvesen.ParkeringsService.Models
{
    public partial class ParkingFacility
    {
        public ParkingFacility()
        {
            ParkingSpotFacilities = new HashSet<ParkingSpotFacility>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ParkingSpotFacility> ParkingSpotFacilities { get; set; }
    }
}
