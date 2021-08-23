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
            //var postcode = Services.GetPostcodeFromUser();
            //var postcodeResult = Services.GetCoordinatesByPostcode(postcode);
            var postcode = "";
            var postcodeResult = new PostcodeResult();

            while (postcodeResult.Status != 200)
            {
                postcode = Services.GetPostcodeFromUser();
                postcodeResult = Services.GetCoordinatesByPostcode(postcode);
            }

            var coordinates = postcodeResult.Result;
            var stops = Services.GetBusStopsFromCoordinates(coordinates.Latitude, coordinates.Longitude);

            var stop1 = stops[0];
            Console.WriteLine($"Stop {stop1}");
            var buses1 = Services.GetBusesForBusStop(stop1.NaptanId);

            var stop2 = stops[1];
            var buses2 = Services.GetBusesForBusStop(stop2.NaptanId);

            Services.PrintNexFiveBuses(buses1);
            Services.PrintNexFiveBuses(buses2);
        }
    }
}