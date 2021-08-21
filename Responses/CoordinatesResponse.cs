using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStopDotnet.Responses
{
    class CoordinatesResponse
    {
        [JsonProperty("postcode")]
        public string Postcode { get; set; }
        [JsonProperty("longitude")]
        public decimal Longitude { get; set; }
        [JsonProperty("latitude")]
        public decimal Latitude { get; set; }
    }

    class PostcodeResult
    {
        public int Status { get; set; }
        public CoordinatesResponse Result { get; set; }
    }
}
