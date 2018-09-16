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
        private const string EhEntityPath = "truckevent";
        private readonly IConfiguration Config;
        private string EhConnectionString;

        public TruckEventHub(IConfiguration config)
        {
            Config = config;
            EhConnectionString = Config["ConnectionStrings:EventHub"];
        }
        public async void SendTrcuk(Truck truck)
        {
            _eventHubClient = EventHubClient.CreateFromConnectionString(connectionStringBuilder());

            string json = JsonConvert.SerializeObject(truck);

            await _eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(json)));

            await _eventHubClient.CloseAsync();
        }
        
        private string connectionStringBuilder()
        {
            var connString = new EventHubsConnectionStringBuilder(EhConnectionString);

            return connString.EntityPath = EhEntityPath;
        }

    }
}
