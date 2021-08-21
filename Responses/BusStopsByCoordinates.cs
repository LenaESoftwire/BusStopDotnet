using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStopDotnet.Responses
{
    class BusStopNaptan
    {
        [JsonProperty("stationNaptan")]
        public string NaptanId { get; set; }
    }

    class BusStopsByCoordinates
    {
        [JsonProperty("stopPoints")]
        public List<BusStopNaptan> StopPoints { get; set; }
    }

}
