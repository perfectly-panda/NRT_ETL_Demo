using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NRT_ETL_Demo
{
    public static class HubToGrid
    {
        [FunctionName("HubToGrid")]
        public static void Run([EventHubTrigger("truckevent", Connection = "EventHub")]string myEventHubMessage, TraceWriter log)
        {
            string topicEndpoint = ConfigurationManager.AppSettings["EventGridUrl"];
            string sasKey = ConfigurationManager.AppSettings["EventGridKey"];

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("aeg-sas-key", sasKey);
            client.DefaultRequestHeaders.UserAgent.ParseAdd("functionsclient");

            List<GridEvent<object>> eventList = new List<GridEvent<object>>();

            eventList.Add(new GridEvent<object>()
            {
                Subject = $"New Truck Event",
                EventType = "allEvents",
                EventTime = DateTime.UtcNow,
                Id = Guid.NewGuid().ToString(),
                Data = myEventHubMessage
            });

            string json = JsonConvert.SerializeObject(eventList);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, topicEndpoint)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            var result = client.SendAsync(request).Result;

            var text = result.Content.ReadAsStringAsync().Result;

            log.Info(text);
        }
    }
}
