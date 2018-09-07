using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace NRT_ETL_Demo
{
    public static class CreateTrucks
    {
        [FunctionName("CreateTrucks")]
        public static void Run([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            int trucksPerHour;
            int currentTrucks;

            var sql = @"SELECT SettingValue FROM dbo.Settings
                    WHERE SettingName = 'TrucksPerHour'";

            var trucks = @"SELECT Count(*) FROM dbo.Truck
                    WHERE EnterDCTime >= DATEADD(hour, -1, getdate())";

            var addTruck = @"INSERT INTO dbo.Truck
                    (Pallets, EnterDCTime)
                    VALUES
                    (@pallets, @enterDC)";

            var str = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(str))
            {

                trucksPerHour = Int32.Parse(conn.Query<string>(sql).FirstOrDefault());

                currentTrucks = conn.Query<int>(trucks).FirstOrDefault();

                if (ProbabilityCheck.ShouldCreate(trucksPerHour, currentTrucks))
                {
                    var pallets = ProbabilityCheck.PalletCount();
                    var enterDC = DateTime.Now;

                    conn.Execute(addTruck, new { pallets, enterDC });
                }

            }
        }

    }
}
