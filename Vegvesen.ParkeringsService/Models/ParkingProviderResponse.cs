using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Vegvesen.ParkeringsService.Models
{
    public class ParkingProviderResponse
    {

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("organisasjonsnummer")]
        public long Organisasjonsnummer { get; set; }

        [JsonProperty("navn")]
        public string Navn { get; set; }
    }
}