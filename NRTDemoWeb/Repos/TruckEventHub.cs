using Microsoft.Azure.EventHubs;
using Microsoft.Extensions.Configuration;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRTDemoWeb.Repos
{
    public class TruckEventHub
    {
        private static EventHubClient _eventHubClient;
        private readonly IConfiguration Config;
        private string EhConnectionString;

        public TruckEventHub(IConfiguration config)
        {
            Config = config;
            EhConnectionString = Config["ConnectionStrings:EventHub"];
        }
        public async void SendTruck(Truck truck)
        {
            try
            {
                _eventHubClient = EventHubClient.CreateFromConnectionString(EhConnectionString);

                string json = JsonConvert.SerializeObject(truck);

                await _eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(json)));

                await _eventHubClient.CloseAsync();
            }

        catch(Exception e)
            {
                await _eventHubClient.CloseAsync();
            }
        }

    }
}
