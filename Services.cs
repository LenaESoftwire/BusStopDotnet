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
        public static PostcodeResult GetCoordinatesByPostcode(string postcode)
        {
            var client = new RestClient("http://api.postcodes.io/");
            var request = new RestRequest($"Postcodes/{postcode}", DataFormat.Json);
            var response = client.Get<PostcodeResult>(request).Data;
            if (response.Status == 404)
            {
                Console.WriteLine(response.Error);
            }

            return response;
        }

        public static List<BusStop> GetBusStopsFromCoordinates(decimal latitude, decimal longitude)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/?lat={latitude}&lon={longitude}&stopTypes=NaptanPublicBusCoachTram&radius=1000", DataFormat.Json);
            var response = client.Get<BusStopsFromCoordinates>(request).Data;
            var stops = response.StopPoints.Where(s => s.Modes.Contains("bus")).ToList();
            Console.WriteLine($"There are {stops.Count} bus stops around");

            return stops;
        }

        public static List<BusesForBusStop> GetBusesForBusStop(string busStop)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{busStop}/Arrivals", DataFormat.Json);
            var response = client.Get<List<BusesForBusStop>>(request);

            return response.Data;
        }

        public static string GetPostcodeFromUser()
        {
            Console.Write("Please input your postcode: ");
            return Console.ReadLine();
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
    }
}
