using BusStopDotnet.Responses;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStopDotnet
{
    class Program
    {
        public static bool ready = false;
        static void Main(string[] args)
        {
            var stopId = Helper.GetBusStopNaptanId();
            var buses = Helper.GetBusesForBusStop(stopId).Result;
            while (!ready) ;

            if (buses.Count == 1)
            {
                Console.WriteLine($"Couln't find any buses coming from {stopId} bus stop");
            }

            else
            {
                Helper.PrintNexFiveBuses(buses);
            }
        }

        class Helper
        {
            public static async Task<List<BusStopResponse>> GetBusesForBusStop(string busStop)
            {
                var client = new RestClient("https://api.tfl.gov.uk/");
                var request = new RestRequest($"StopPoint/{busStop}/Arrivals", DataFormat.Json);

                var response = await client.GetAsync<List<BusStopResponse>>(request);
                ready = true;
                Console.WriteLine(response.Count);

                return response;
            }

            public static void PrintNexFiveBuses(List<BusStopResponse> buses)
            {
                buses.Sort(delegate (BusStopResponse x, BusStopResponse y)
                {
                    return x.TimeToStation.CompareTo(y.TimeToStation);
                });

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

            public static string GetBusStopNaptanId()
            {
                Console.Write("Please input Bus Stop NaptanId: ");
                return Console.ReadLine();
            }
        }
    }
}