using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Models;
using NRTDemoWeb.Repos;

namespace NRTDemoWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly IConfiguration Config;

        // Constructor that that takes IConfiguration is called on instantiation thanks to Dependency injection
        public TruckController(IConfiguration config)
        {
            Config = config;
        }

        // GET api/trucks
        [HttpGet]
        public ActionResult<IEnumerable<Truck>> Get()
        {
            using(IDbConnection conn = new SqlConnection(Config["ConnectionStrings:DatabaseConnection"]))
            {
                var repo = new TruckRepository(conn);

                return repo.GetActiveTrucks().ToList();

            }
        }

        // GET api/trucks/5
        [HttpGet("{id}")]
        public ActionResult<Truck> Get(int id)
        {
            using (IDbConnection conn = new SqlConnection(Config["ConnectionStrings:DatabaseConnection"]))
            {
                var repo = new TruckRepository(conn);

                return repo.GetTruck(id);

            }
        }


    }
}
