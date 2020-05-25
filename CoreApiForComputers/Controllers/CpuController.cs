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
    [Route("api/v{version:apiVersion}/cpus")]
    [Produces("application/xml")]
    public class CpusController : ControllerBase
    {
        private readonly IDatabaseAcces database;
        public CpusController()
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
