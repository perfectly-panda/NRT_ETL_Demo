using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid;
using Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;

namespace NRT_ETL_Demo
{
    public static class NewTruck
    {
        [FunctionName("NewTruckNotifications")]
        public static void Run([EventGridTrigger]JObject eventGridEvent, TraceWriter log)
        {
            try
            {
                var gridEvent = eventGridEvent.ToObject<Microsoft.Azure.EventGrid.Models.EventGridEvent>();
                log.Info("Received Event");

                var truck = JsonConvert.DeserializeObject<Truck>(gridEvent.Data.ToString());

                log.Info($"Truck Id: {truck.TruckId}");

                List<GridEvent<object>> eventList = new List<GridEvent<object>>();

                var message = new Message();

                switch (truck.Status)
                {
                    case 1:

                        if (truck.Pallets > 150)
                        {
                            message.Level = "Warning";
                        }
                        else
                        {
                            message.Level = "Info";
                        }

                        message.MessageText = $"Truck {truck.TruckId} created. Pallet count: {truck.Pallets}";
                        break;
                    case 4:
                        var span = (TimeSpan)(truck.UnloadStopTime - truck.UnloadStartTime);
                        if (span.Minutes > 60)
                        {
                            message.Level = "Error";
                        }
                        else
                        {
                            message.Level = "Info";
                        }

                        message.MessageText = $"Truck {truck.TruckId} unloaded. Unload Time: {span}";
                        break;
                    case 6:
                        var total = (TimeSpan)(truck.EnterDCTime - truck.LeaveDCTime);

                        message.Level = "Info";

                        message.MessageText = $"Truck {truck.TruckId} unloaded. Total Time: {total}";
                        break;
                }

                if (!String.IsNullOrEmpty(message.MessageText))
                {
                    eventList.Add(new GridEvent<object>()
                    {
                        Subject = $"Unloaded Truck Event",
                        EventType = "allEvents",
                        EventTime = DateTime.UtcNow,
                        Id = Guid.NewGuid().ToString(),
                        Data = message
                    });



                    string topicEndpoint = ConfigurationManager.AppSettings["NotificationUrl"];
                    string sasKey = ConfigurationManager.AppSettings["NotificationKey"];

                    HttpClient client = new HttpClient();
                    client.DefaultRequestHeaders.Add("aeg-sas-key", sasKey);
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("functionsclient");

                    string json = JsonConvert.SerializeObject(eventList);

                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, topicEndpoint)
                    {
                        Content = new StringContent(json, Encoding.UTF8, "application/json")
                    };

                    var result = client.SendAsync(request).Result;

                    var text = result.Content.ReadAsStringAsync().Result;
                    log.Info(result.StatusCode.ToString());
                    log.Info(result.ReasonPhrase);
                }
            }
            catch (Exception e)
            {
                log.Error(e.Message);
            }
        }
    }
}