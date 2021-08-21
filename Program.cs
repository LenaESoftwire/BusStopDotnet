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
            var coordinates = Helper.GetCoordinatesByPostcode();

            var stops = Helper.GetNaptanIds(coordinates.Latitude, coordinates.Longitude);

            var stopNaptan = stops.StopPoints[0].NaptanId;
            Console.WriteLine($"Stop {stopNaptan}");

            //var stopId = Helper.GetBusStopNaptanId();
            var buses = Helper.GetBusesForBusStop(stopNaptan);

            if (buses.Count == 1)
            {
                Console.WriteLine($"Couln't find any buses coming from {stopNaptan} bus stop");
            }

            else
            {
                Helper.PrintNexFiveBuses(buses);
            }
        }

        class Helper
        {
            public static List<BusStopResponse> GetBusesForBusStop(string busStop)
            {
                var client = new RestClient("https://api.tfl.gov.uk/");
                var request = new RestRequest($"StopPoint/{busStop}/Arrivals", DataFormat.Json);
                var response = client.Get<List<BusStopResponse>>(request);
                Console.WriteLine($"There are {response.Data.Count} stops around");

                return response.Data;
            }

            public static CoordinatesResponse GetCoordinatesByPostcode()
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

            public static BusStopListResponse GetNaptanIds(decimal latitude, decimal longitude)
            {
                var client = new RestClient("https://api.tfl.gov.uk/");
                var request = new RestRequest($"StopPoint/?lat={latitude}&lon={longitude}&stopTypes=NaptanPublicBusCoachTram&radius=1000", DataFormat.Json);
                var response = client.Get<BusStopListResponse>(request).Data;
                Console.WriteLine(response.StopPoints.Count);

                return response;


            }

            public static void PrintNexFiveBuses(List<BusStopResponse> buses)
            {
                buses.Sort(delegate (BusStopResponse x, BusStopResponse y)
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
}