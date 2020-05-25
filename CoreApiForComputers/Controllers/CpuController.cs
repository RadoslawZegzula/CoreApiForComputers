using CoreApiForComputers.DataBase;
using CoreApiForComputers.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiForComputers.Controllers
{
    [ApiController]
    [Route("/api/cpu")]
    public class CpuController : ControllerBase
    {
        private readonly IDatabaseAcces database;
        public CpuController()
        {
            database = new MemoryDatabase();
        }
        [HttpGet()]
        public IActionResult GetCpu()
        {
            var cpuEntities = database.Read<CpuEntity>();
            return Ok(cpuEntities);
        }

    }
}
