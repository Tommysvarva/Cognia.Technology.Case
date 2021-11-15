using System;
using System.Collections.Generic;

#nullable disable

namespace Vegvesen.ParkeringsService.Models
{
    public partial class ParkingSpot
    {
        public ParkingSpot()
        {
            ParkingProviderSpots = new HashSet<ParkingProviderSpot>();
            ParkingSpotFacilities = new HashSet<ParkingSpotFacility>();
        }

        public int Id { get; set; }
        public string ParkeringstilbyderNavn { get; set; }
        public double? Breddegrad { get; set; }
        public double? Lengdegrad { get; set; }
        public string Deaktivert { get; set; }
        public int? Versjonsnummer { get; set; }
        public string Navn { get; set; }
        public string Adresse { get; set; }
        public int? Postnummer { get; set; }
        public string Poststed { get; set; }
        public string Aktiveringstidspunkt { get; set; }

        public virtual ICollection<ParkingProviderSpot> ParkingProviderSpots { get; set; }
        public virtual ICollection<ParkingSpotFacility> ParkingSpotFacilities { get; set; }
    }
}
