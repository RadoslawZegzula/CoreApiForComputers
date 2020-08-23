using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.FiltringParameters;
using CoreApiForComputers.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreApiForComputers.Controllers
{
    /// <summary>
    /// Controller for central_processing_units
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/cpus")]
    [Produces("application/xml")]
    public class CpusController : ControllerBase
    {
        private readonly IGenericRepository<CpuEntity> database;

        /// <summary>
        /// The constructor initialize database access
        /// by dependency injection
        /// </summary>
        /// <param name="data"></param>
        public CpusController(IGenericRepository<CpuEntity> data)
        {
            database = data;
        }

        /// <summary>
        /// Returns collection of all central_processing_units
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
        /// Returns collection of a filtered central_processing_units
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of central_processing_unit </returns>
        [HttpGet("filter", Name = "GetCpusWithFilter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCpusWithFilter(
            [FromQuery] BasePartFiltringParameters basePartFiltringParameters)
        {
            if (basePartFiltringParameters == null)
            {
                return BadRequest();
            }
        
            var cpuEntities = database.Read<CpuEntity>(basePartFiltringParameters);
            return Ok(cpuEntities);
        }

        /// <summary>
        /// Returns one central_processing_unit
        /// </summary>
        /// <param name="cpuId">The id of the CpuEntity you want to get</param>
        /// <returns>An ActionResult of type CpuEntity</returns>
        [HttpGet("{cpuId}", Name = "GetCpu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CpuEntity> GetCpu(int cpuId)
        {
            var cpuEntity = database.Read<CpuEntity>(cpuId);

            return Ok(cpuEntity);
        }

        /// <summary>
        /// Create one central_processing_unit and results 
        /// created central_processing_unit
        /// </summary>
        /// <param name="cpuForCreation">The central_processing_unit to create</param>
        /// <returns>An ActionResult of type CpuEntity </returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CpuEntity> CreateCpu([FromBody] CpuEntity cpuForCreation)
        {
            if (database.Read<CpuEntity>(cpuForCreation.Id) != null)
            {
                return UnprocessableEntity();
            }

            database.Create<CpuEntity>(cpuForCreation);
            return CreatedAtRoute("GetCpu", new {cpuId = cpuForCreation.Id }, cpuForCreation);
        }

        /// <summary>
        /// Update one central_processing_unit if this exist
        /// </summary>
        /// <param name="cpuId">Identificator of central_processing_unit to update</param>
        /// <param name="cpuForCreation">The central_processing_unit to update</param>
        /// <returns>Nothing </returns>
        [HttpPatch("{cpuId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<CpuEntity> UpdateCpu(int cpuId, [FromBody] CpuEntity cpuForCreation)
        {
            if (database.Read<CpuEntity>(cpuForCreation.Id) == null)
            {
                return NotFound();
            }

            database.Update<CpuEntity>(cpuForCreation);

            return NoContent();
        }

        /// <summary>
        /// Delete one central_processing_unit if this exist
        /// </summary>
        /// <param name="cpuId">Identificator of central_processing_unit for deletion</param>
        /// <returns>Nothing</returns>
        [HttpDelete("{cpuId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult DeleteCpu(int cpuId)
        {
            var cpuToDelete = database.Read<CpuEntity>(cpuId);

            if (cpuToDelete == null)
            {
                return NotFound();
            }

            database.Delete<CpuEntity>(cpuToDelete);

            return NoContent();
        }
    }
}
