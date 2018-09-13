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
            var sql = @"";
        }
    }
}
