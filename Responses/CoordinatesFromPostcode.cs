using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStopDotnet.Responses
{
    class CoordinatesFromPostcode
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
        public CoordinatesFromPostcode Result { get; set; }
        public string Error { get; set; }
    }
}
