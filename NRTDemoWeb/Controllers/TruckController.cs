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

        [HttpGet("Create/{pallets}")]
        public ActionResult CreateTruck(int pallets)
        {
            using (IDbConnection conn = new SqlConnection(Config["ConnectionStrings:DatabaseConnection"]))
            {
                var repo = new TruckRepository(conn);

                var truck = new Truck()
                {
                    Pallets = pallets,
                    EnterDCTime = DateTime.UtcNow
                };

                var result = repo.CreateTruck(truck);

                var eventHub = new TruckEventHub(Config);

                eventHub.SendTruck(result);

                return Ok();

            }
        }

        [HttpGet("Move/{id}")]
        public ActionResult MoveTruck(int id)
        {
            using (IDbConnection conn = new SqlConnection(Config["ConnectionStrings:DatabaseConnection"]))
            {

                var repo = new TruckRepository(conn);

                var result = repo.GetTruck(id);

                switch (result.Status)
                {
                    case 1:
                        result.DockStartTime = DateTime.UtcNow;
                        break;
                    case 2:
                        result.UnloadStartTime = DateTime.UtcNow;
                        break;
                    case 3:
                        result.UnloadStopTime = DateTime.UtcNow;
                        break;
                    case 4:
                        result.DockEndTime = DateTime.UtcNow;
                        break;
                    case 5:
                        result.LeaveDCTime = DateTime.UtcNow;
                        break;
                }

                result = repo.UpdateTruck(result);

                var eventHub = new TruckEventHub(Config);

                eventHub.SendTruck(result);

                return Ok();

            }
        }


    }
}
