using BusStopDotnet.Responses;
using RestSharp;
using System;
using System.Collections.Generic;

namespace BusStopDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            var coordinates = Services.GetCoordinatesByPostcode();

            var stops = Services.GetNaptanIds(coordinates.Latitude, coordinates.Longitude);

            var stopNaptan1 = stops.StopPoints[0].NaptanId;
            Console.WriteLine($"Stop {stopNaptan1}");
            var buses1 = Services.GetBusesForBusStop(stopNaptan1);

            var stopNaptan2 = stops.StopPoints[1].NaptanId;
            var buses2 = Services.GetBusesForBusStop(stopNaptan2);

            Services.PrintNexFiveBuses(buses1);
            Services.PrintNexFiveBuses(buses2);
        }

        
    }
}