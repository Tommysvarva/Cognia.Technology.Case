using System;
using System.Collections.Generic;

#nullable disable

namespace Vegvesen.ParkeringsService.Models
{
    public partial class ParkingProvider
    {
        public ParkingProvider()
        {
            ParkingProviderSpots = new HashSet<ParkingProviderSpot>();
        }

        public int Id { get; set; }
        public int? Organisasjonsnummer { get; set; }
        public string Navn { get; set; }

        public virtual ICollection<ParkingProviderSpot> ParkingProviderSpots { get; set; }
    }
}
