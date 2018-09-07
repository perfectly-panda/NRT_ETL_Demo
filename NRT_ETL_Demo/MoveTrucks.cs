using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Models;

namespace NRT_ETL_Demo
{
    public static class MoveTrucks
    {
        [FunctionName("MoveTrucks")]
        public static void Run([TimerTrigger("*/15 * * * * *")]TimerInfo myTimer, TraceWriter log)
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

                conn.Execute(trucksEnterDCUpdate, UpdateTrucks(conn.Query<TruckCheck>(trucksEnterDCSelect).ToList(), checkInt));
                conn.Execute(dockStartUpdate, UpdateTrucks(conn.Query<TruckCheck>(dockStartSelect).ToList(), checkInt));
                conn.Execute(unloadEndUpdate, UpdateTrucks(conn.Query<TruckCheck>(unloadEndSelect).ToList(), checkInt));
                conn.Execute(dockEndUpdate, UpdateTrucks(conn.Query<TruckCheck>(dockEndSelect).ToList(), checkInt));

            }
        }

        private static List<TruckCheck> UpdateTrucks(List<TruckCheck> trucks, int checkInt)
        {
            List<TruckCheck> toMove = new List<TruckCheck>();

            foreach(var truck in trucks)
            {
                var span = (DateTime.Now - truck.Stamp).Minutes;

                if (ProbabilityCheck.ShouldCreate(checkInt, span))
                {
                    truck.NextStamp = DateTime.UtcNow;
                    toMove.Add(truck);
                }
            }

            return toMove;
        }
    }
}
