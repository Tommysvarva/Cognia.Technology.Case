using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vegvesen.ParkeringsService.Models
{
    public class ParkingSpotResponse
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("parkeringstilbyderNavn")]
        public string ParkeringstilbyderNavn { get; set; }

        [JsonProperty("breddegrad")]
        public double Breddegrad { get; set; }

        [JsonProperty("lengdegrad")]
        public double Lengdegrad { get; set; }

        [JsonProperty("deaktivert")]
        public object Deaktivert { get; set; }

        [JsonProperty("versjonsnummer")]
        public long Versjonsnummer { get; set; }

        [JsonProperty("navn")]
        public string Navn { get; set; }

        [JsonProperty("adresse")]
        public string Adresse { get; set; }

        [JsonProperty("postnummer")]
        public string Postnummer { get; set; }

        [JsonProperty("poststed")]
        public string Poststed { get; set; }

        [JsonProperty("aktiveringstidspunkt")]
        public DateTimeOffset Aktiveringstidspunkt { get; set; }
    }
}
