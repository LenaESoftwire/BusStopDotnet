using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStopDotnet.Responses
{
    class BusStopResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("vehicleId")]
        public string VehicleId { get; set; }

        [JsonProperty("naptanId")]
        public string NaptanId { get; set; }

        [JsonProperty("stationName")]
        public string StationName { get; set; }

        [JsonProperty("lineId")]
        public string LineId { get; set; }

        [JsonProperty("lineName")]
        public string LineName { get; set; }
        
        [JsonProperty("platformName")]
        public string PlatformName { get; set; }

        [JsonProperty("bearing")]
        public int Bearing { get; set; }
        
        [JsonProperty("destinationNaptanId")]
        public string DestinationStopID { get; set; }

        [JsonProperty("destinationName")]
        public string DestinationName { get; set; }

        [JsonProperty("timestamp")]
        public DateTime UtcTime { get; set; }
        
        [JsonProperty("timeToStation")]
        public int TimeToStation { get; set; }
        
        [JsonProperty("currentLocation")]
        public string CurrentLocation { get; set; }

        public string Towards { get; set; }

        [JsonProperty("expectedArrival")]
        public DateTime ExpectedAtUtc { get; set; }

        public string ModeName { get; set; }

    }


    //"$type": "Tfl.Api.Presentation.Entities.Prediction, Tfl.Api.Presentation.Entities",
    //"id": "1717940254",
    //"operationType": 1,
    //"vehicleId": "LA19KAE",
    //"naptanId": "490008660N",
    //"stationName": "Lady Somerset Road",
    //"lineId": "214",
    //"lineName": "214",
    //"platformName": "GY",
    //"direction": "inbound",
    //"bearing": "316",
    //"destinationNaptanId": "",
    //"destinationName": "Highgate Village",
    //"timestamp": "2021-08-18T20:42:00.0577943Z",
    //"timeToStation": 886,
    //"currentLocation": "",
    //"towards": "Highgate Village or Parliament Hill Fields",
    //"expectedArrival": "2021-08-18T20:56:46Z",
    //"timeToLive": "2021-08-18T20:57:16Z",
    //"modeName": "bus",
    //"timing": {
    //  "$type": "Tfl.Api.Presentation.Entities.PredictionTiming, Tfl.Api.Presentation.Entities",
    //  "countdownServerAdjustment": "00:00:24.9324166",
    //  "source": "2021-08-18T19:50:42.361Z",
    //  "insert": "2021-08-18T20:42:18.84Z",
    //  "read": "2021-08-18T20:42:43.798Z",
    //  "sent": "2021-08-18T20:42:00Z",
    //  "received": "0001-01-01T00:00:00Z"
    //}
}
