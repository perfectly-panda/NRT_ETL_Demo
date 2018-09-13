using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.ServiceBus;
using Models;
using Newtonsoft.Json;

namespace NRT_ETL_Demo
{
    public static class UnloadTrucks
    {
        [FunctionName("UnloadTrucks")]
        public static void Run([TimerTrigger("*/15 * * * * *")]TimerInfo myTimer, TraceWriter log,
            [EventHub("truckevent", Connection = "EventHub")] ICollector<string> outputEventHubMessage)
        {

            var unloadSelect = @"SELECT TruckId ,[Pallets]
                          ,[EnterDCTime]
                          ,[DockStartTime]
                          ,[UnloadStartTime]
                          ,[UnloadStopTime]
                          ,[DockEndTime]
                          ,[LeaveDCTime], EnterDCTime AS Stamp, Pallets FROM dbo.Truck
                    WHERE UnloadStartTime <= DATEADD(minute, -5, getdate())
                    AND UnloadStopTime IS NULL";

            var unloadUpdate = @"UPDATE dbo.Truck
                    SET UnloadStopTime = @NextStamp
                    WHERE TruckId = @TruckId";

            var settingQuery = @"SELECT SettingValue FROM dbo.Settings
                    WHERE SettingName = 'PalletsPerHour'";


            var str = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {
                var setting = Int32.Parse(conn.Query<string>(settingQuery).FirstOrDefault());

                var unloads = conn.Query<Truck>(unloadSelect).ToList();

                foreach (var truck in unloads)
                {
                    decimal time = (DateTime.UtcNow - truck.Stamp).Minutes / 60;

                    if (ProbabilityCheck.ShouldCreate(truck.Pallets, (int)Math.Floor(setting * time)))
                    {
                        truck.NextStamp = DateTime.UtcNow;
                        truck.UnloadEndTime = DateTime.UtcNow;

                        string json = JsonConvert.SerializeObject(truck);

                        outputEventHubMessage.Add(json);

                        conn.Execute(unloadUpdate, truck);
                    }
                }

            }
        }
    }
}
