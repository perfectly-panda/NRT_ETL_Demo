using System;
using System.Collections.Generic;
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
    public static class MoveTrucks
    {
        [FunctionName("MoveTrucks")]
        public static void Run([TimerTrigger("*/15 * * * * *")]TimerInfo myTimer, TraceWriter log,
            [EventHub("truckevent", Connection = "EventHub")] ICollector<string> outputEventHubMessage)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

            var trucksEnterDCSelect = @"SELECT [TruckId]
                          ,[Pallets]
                          ,[EnterDCTime]
                          ,[DockStartTime]
                          ,[UnloadStartTime]
                          ,[UnloadStopTime]
                          ,[DockEndTime]
                          ,[LeaveDCTime]
                          ,EnterDCTime AS Stamp FROM dbo.Truck
                    WHERE EnterDCTime <= DATEADD(minute, -5, getdate())
                    AND DockStartTime IS NULL";

            var dockStartSelect = @"SELECT TruckId ,[Pallets]
                          ,[EnterDCTime]
                          ,[DockStartTime]
                          ,[UnloadStartTime]
                          ,[UnloadStopTime]
                          ,[DockEndTime]
                          ,[LeaveDCTime], EnterDCTime AS Stamp FROM dbo.Truck
                    WHERE DockStartTime <= DATEADD(minute, -5, getdate())
                    AND UnloadStartTime IS NULL";

            var unloadEndSelect = @"SELECT TruckId ,[Pallets]
                          ,[EnterDCTime]
                          ,[DockStartTime]
                          ,[UnloadStartTime]
                          ,[UnloadStopTime]
                          ,[DockEndTime]
                          ,[LeaveDCTime], EnterDCTime AS Stamp FROM dbo.Truck
                    WHERE UnloadStopTime <= DATEADD(minute, -5, getdate())
                    AND DockEndTime IS NULL";

            var dockEndSelect = @"SELECT TruckId ,[Pallets]
                          ,[EnterDCTime]
                          ,[DockStartTime]
                          ,[UnloadStartTime]
                          ,[UnloadStopTime]
                          ,[DockEndTime]
                          ,[LeaveDCTime], EnterDCTime AS Stamp FROM dbo.Truck
                    WHERE DockEndTime <= DATEADD(minute, -5, getdate())
                    AND LeaveDCTime IS NULL";

            var trucksEnterDCUpdate = @"UPDATE dbo.Truck
                    SET DockStartTime = @NextStamp
                    WHERE TruckId = @TruckId";

            var dockStartUpdate = @"UPDATE dbo.Truck
                    SET UnloadStartTime = @NextStamp
                    WHERE TruckId = @TruckId";

            var unloadEndUpdate = @"UPDATE dbo.Truck
                    SET DockEndTime = @NextStamp
                    WHERE TruckId = @TruckId";

            var dockEndUpdate = @"UPDATE dbo.Truck
                    SET LeaveDCTime = @NextStamp
                    WHERE TruckId = @TruckId";

            var settingQuery = @"SELECT SettingValue FROM dbo.Settings
                    WHERE SettingName = 'MovementTime'";

            var str = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {
                var checkInt = Int32.Parse(conn.Query<string>(settingQuery).FirstOrDefault());

                var enterDC = conn.Query<Truck>(trucksEnterDCSelect).ToList();

                foreach(var truck in enterDC)
                {
                    var span = (DateTime.Now - truck.Stamp).Minutes;

                    if (ProbabilityCheck.ShouldCreate(span, checkInt))
                    {
                        truck.NextStamp = DateTime.UtcNow;
                        truck.DockStartTime = DateTime.UtcNow;

                        string json = JsonConvert.SerializeObject(truck);

                        outputEventHubMessage.Add(json);

                        conn.Execute(trucksEnterDCUpdate, truck);
                    }
                }

                var dockStart = conn.Query<Truck>(dockStartSelect).ToList();

                foreach (var truck in dockStart)
                {
                    var span = (DateTime.Now - truck.Stamp).Minutes;

                    if (ProbabilityCheck.ShouldCreate(span, checkInt))
                    {
                        truck.NextStamp = DateTime.UtcNow;
                        truck.UnloadStartTime = DateTime.UtcNow;

                        string json = JsonConvert.SerializeObject(truck);

                        outputEventHubMessage.Add(json);

                        conn.Execute(dockStartUpdate, truck);
                    }
                }

                var unloadEnd = conn.Query<Truck>(unloadEndSelect).ToList();

                foreach (var truck in unloadEnd)
                {
                    var span = (DateTime.Now - truck.Stamp).Minutes;

                    if (ProbabilityCheck.ShouldCreate(span, checkInt))
                    {
                        truck.NextStamp = DateTime.UtcNow;
                        truck.DockEndTime = DateTime.UtcNow;

                        string json = JsonConvert.SerializeObject(truck);

                        outputEventHubMessage.Add(json);

                        conn.Execute(unloadEndUpdate, truck);
                    }
                }

                var dockEnd = conn.Query<Truck>(dockEndSelect).ToList();

                foreach (var truck in dockEnd)
                {
                    var span = (DateTime.Now - truck.Stamp).Minutes;

                    if (ProbabilityCheck.ShouldCreate(span, checkInt))
                    {
                        truck.NextStamp = DateTime.UtcNow;
                        truck.LeaveDCTime = DateTime.UtcNow;

                        string json = JsonConvert.SerializeObject(truck);

                        outputEventHubMessage.Add(json);

                        conn.Execute(dockEndUpdate, truck);
                    }
                }

            }
        }
    }
}
