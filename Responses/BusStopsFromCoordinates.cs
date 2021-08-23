using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStopDotnet.Responses
{
    class BusStop
    {
        [JsonProperty("stationNaptan")]
        public string NaptanId { get; set; }

        [JsonProperty("modes")]
        public List<string> Modes { get; set; }
    }

    class BusStopsFromCoordinates
    {
        [JsonProperty("stopPoints")]
        public List<BusStop> StopPoints { get; set; }
    }

}
