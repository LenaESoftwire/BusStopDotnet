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
    public interface IBusService
    {
        void GetBusesForBusStop(string busStop);

    }
    //class ApiService : IBusService
    //{
    //    public void GetBusesForBusStop(string busStop)
    //    {
    //        var client = new RestClient("https://api.tfl.gov.uk/");
    //        var request = new RestRequest($"StopPoint/{busStop}/Arrivals", DataFormat.Json);

    //        var response = client.Get<BusStopResponse>(request);
    //        Console.WriteLine(response);
    //    }
    //}
}
