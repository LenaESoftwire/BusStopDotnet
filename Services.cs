using BusStopDotnet.Responses;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStopDotnet
{
    class Services
    {
        public static List<BusesForBusStop> GetBusesForBusStop(string busStop)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{busStop}/Arrivals", DataFormat.Json);
            var response = client.Get<List<BusesForBusStop>>(request);

            return response.Data;
        }

        public static CoordinatesByPostcode GetCoordinatesByPostcode()
        {
            Console.Write("Please input your postcode: ");
            var postcode = Console.ReadLine();
            var client = new RestClient("http://api.postcodes.io/");
            var request = new RestRequest($"Postcodes/{postcode}", DataFormat.Json);
            var response = client.Get<PostcodeResult>(request).Data;
            var coordinates = response.Result;
            Console.WriteLine(coordinates.Longitude);
            Console.WriteLine(coordinates.Latitude);
            Console.WriteLine(coordinates.Postcode);

            return response.Result;
        }

        public static BusStopsByCoordinates GetNaptanIds(decimal latitude, decimal longitude)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/?lat={latitude}&lon={longitude}&stopTypes=NaptanPublicBusCoachTram&radius=1000", DataFormat.Json);
            var response = client.Get<BusStopsByCoordinates>(request).Data;
            Console.WriteLine($"There are {response.StopPoints.Count} stops around");

            return response;
        }

        public static void PrintNexFiveBuses(List<BusesForBusStop> buses)
        {
            buses.Sort(delegate (BusesForBusStop x, BusesForBusStop y)
            {
                return x.TimeToStation.CompareTo(y.TimeToStation);
            });

            if (buses.Count > 0)
            {
                Console.WriteLine($"Busstop {buses[0].NaptanId} {buses[0].StationName}");
                Console.WriteLine("Here are the next 5 arriving buses");
                for (var i = 0; (i < buses.Count && i < 5); i++)
                {
                    var bus = buses[i];
                    Console.Write($"Bus number {bus.LineId} ");
                    Console.Write($"going to {bus.DestinationName} ");
                    Console.WriteLine($"arrives to platform {bus.PlatformName} in {bus.TimeToStation / 60} min");
                }
            }
        }

        public static string GetBusStopNaptanId()
        {
            Console.Write("Please input Bus Stop NaptanId: ");
            return Console.ReadLine();
        }
    }
}
