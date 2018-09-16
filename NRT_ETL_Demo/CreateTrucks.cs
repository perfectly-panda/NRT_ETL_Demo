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
    public static class CreateTrucks
    {
        [FunctionName("CreateTrucks")]
        public static void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, 
            [EventHub("truckevent", Connection = "EventHub")]ICollector<string> outputEventHubMessage,
            TraceWriter log)
        {
            int trucksPerHour;
            int currentTrucks;

            var sql = @"SELECT SettingValue FROM dbo.Settings
                    WHERE SettingName = 'TrucksPerHour'";

            var trucks = @"SELECT Count(*) FROM dbo.Truck
                    WHERE EnterDCTime >= DATEADD(hour, -1, getdate())";

            var addTruck = @"INSERT INTO dbo.Truck
                    (Pallets, EnterDCTime)
                    OUTPUT inserted.TruckId
                    VALUES
                    (@Pallets, @EnterDCTime)";

            var str = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {

                trucksPerHour = Int32.Parse(conn.Query<string>(sql).FirstOrDefault());

                currentTrucks = conn.Query<int>(trucks).FirstOrDefault();

                while(ProbabilityCheck.ShouldCreate(trucksPerHour, currentTrucks))
                {
                    var truck = new Truck();

                    truck.Pallets = ProbabilityCheck.PalletCount();
                    truck.EnterDCTime = DateTime.UtcNow;
                    
                    var truckId = conn.Query<int>(addTruck, truck).FirstOrDefault();

                    truck.TruckId = truckId;

                    string json = JsonConvert.SerializeObject(truck);

                    outputEventHubMessage.Add(json);

                    currentTrucks++;
                }

            }
        }

    }
}
