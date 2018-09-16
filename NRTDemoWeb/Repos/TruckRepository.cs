using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NRTDemoWeb.Repos
{
    public class TruckRepository
    {
        private IDbConnection _conn;

        public TruckRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Truck> GetActiveTrucks()
        {
            var sql = @"SELECT [TruckId]
                  ,[Pallets]
                  ,[EnterDCTime]
                  ,[DockStartTime]
                  ,[UnloadStartTime]
                  ,[UnloadStopTime]
                  ,[DockEndTime]
                  ,[LeaveDCTime]
              FROM [dbo].[Truck]

              where [LeaveDCTime] is null";

            return _conn.Query<Truck>(sql);
        }

        public IEnumerable<Truck> GetRecentTrucks()
        {
            var sql = @"SELECT [TruckId]
                  ,[Pallets]
                  ,[EnterDCTime]
                  ,[DockStartTime]
                  ,[UnloadStartTime]
                  ,[UnloadStopTime]
                  ,[DockEndTime]
                  ,[LeaveDCTime]
              FROM [dbo].[Truck]
             where [EnterDCTime] >= DATEADD(DAY, -1, GETDATE())";

            return _conn.Query<Truck>(sql);
        }

        public Truck GetTruck(int truckId)
        {
            var sql = @"SELECT [TruckId]
                  ,[Pallets]
                  ,[EnterDCTime]
                  ,[DockStartTime]
                  ,[UnloadStartTime]
                  ,[UnloadStopTime]
                  ,[DockEndTime]
                  ,[LeaveDCTime]
              FROM [dbo].[Truck]
              where TruckId = @truckId";

            var result = _conn.Query<Truck>(sql, new {truckId});

            return result.FirstOrDefault();
        }

        public Truck UpdateTruck(Truck truck)
        {
            var sql = @"UPDATE [dbo].[Truck]
               SET [Pallets] = @Pallets
                  ,[EnterDCTime] = @EnterDCTime
                  ,[DockStartTime] = @DockStartTime
                  ,[UnloadStartTime] = @UnloadStartTime
                  ,[UnloadStopTime] = @UnloadStopTime
                  ,[DockEndTime] = @DockEndTime
                  ,[LeaveDCTime] = @LeaveDCTime
              where TruckId = @TruckId";

            var result = _conn.Query<Truck>(sql, truck);

            return GetTruck(truck.TruckId);
        }

        public Truck CreateTruck(Truck truck)
        {
            var sql = @"INSERT [dbo].[Truck]
                    ([Pallets],
                    [EnterDCTime])
	            OUTPUT inserted.TruckId
                VALUES (@Pallets, @EnterDCTime)";

            var result = _conn.Query<int>(sql, truck).FirstOrDefault();

            truck.TruckId = result;

            return truck;
        }
    }
}
