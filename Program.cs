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
            var postcode = "";
            var postcodeResult = new PostcodeResult();

            while (postcodeResult.Status != 200)
            {
                postcode = Services.GetPostcodeFromUser();
                postcodeResult = Services.GetCoordinatesByPostcode(postcode);
            }

            var coordinates = postcodeResult.Result;
            var stops = Services.GetBusStopsFromCoordinates(coordinates.Latitude, coordinates.Longitude);

            if (stops.Count < 1)
            {
                Console.WriteLine($"Sorry, there are no busstops found around {postcode}");
            }

            else
            {
                var stop1 = stops[0];
                var buses1 = Services.GetBusesForBusStop(stop1.NaptanId);

                var stop2 = stops[1];
                var buses2 = Services.GetBusesForBusStop(stop2.NaptanId);

                Services.PrintNexFiveBuses(buses1);
                Services.PrintNexFiveBuses(buses2);
            }
        }
    }
}