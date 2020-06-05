using CoreApiForComputers.DataBase;
using CoreApiForComputers.Models.Entities;
using Microsoft.AspNetCore.Http;
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
        private readonly IRepository database;
        public CpusController()
        {
            database = new MemoryRepository();
        }

        /// <summary>
        /// Get cpus 
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of Cpu </returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCpu()
        {
            var cpuEntities = database.Read<CpuEntity>();
            return Ok(cpuEntities);
        }

        /// <summary>
        /// Get cpu
        /// </summary>
        /// <param name="cpuId">The id of the cpu you want to get</param>
        /// <returns>An ActionResult of type Cpu </returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CpuEntity> GetCpu(int cpuId)
        {
            var cpuEntity = database.ReadById<CpuEntity>(cpuId);

            return Ok(cpuEntity);
        }

    }
}
