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
        /// Get central_processing_units 
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of central_processing_unit </returns>
        [HttpGet(Name = "GetCpus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CpuEntity>> GetCpus()
        {
            var cpuEntities = database.Read<CpuEntity>();
            return Ok(cpuEntities);
        }

        /// <summary>
        /// Get one central_processing_unit
        /// </summary>
        /// <param name="cpuId">The id of the CpuEntity you want to get</param>
        /// <returns>An ActionResult of type CpuEntity </returns>
        [HttpGet("{cpuId}", Name = "GetCpu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CpuEntity> GetCpu(int cpuId)
        {
            var cpuEntity = database.ReadById<CpuEntity>(cpuId);

            return Ok(cpuEntity);
        }

        /// <summary>
        /// Create one central_processing_unit
        /// </summary>
        /// <param name="cpuForCreation">The central_processing_unit to create</param>
        /// <returns>An ActionResult of type CpuEntity </returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CpuEntity> CreateCpu([FromBody] CpuEntity cpuForCreation)
        {
            if (database.ReadById<CpuEntity>(cpuForCreation.Id) == null)
            {
                return UnprocessableEntity();
            }

            database.Create(cpuForCreation);
            return CreatedAtRoute("GetCpu", new {cpuId = cpuForCreation.Id }, cpuForCreation);
        }
    }
}
