using CoreApiForComputers.DataBase.EntityInterfaces;
using CoreApiForComputers.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreApiForComputers.Controllers
{
    /// <summary>
    /// Controller for graphics_processing_units
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/gpus")]
    [Produces("application/xml")]
    public class GpusController : ControllerBase
    {
        private readonly IGpuRepository database;

        /// <summary>
        /// The constructor that initialize database access
        /// by dependency injection
        /// </summary>
        /// <param name="data"></param>
        public GpusController(IGpuRepository data)
        {
            database = data;
        }

        /// <summary>
        /// Returns collection of all graphics_processing_units
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of graphics_processing_units </returns>
        [HttpGet(Name = "GetGpus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<GpuEntity>> GetGpus()
        {
            var gpuEntities = database.Read();
            return Ok(gpuEntities);
        }

        /// <summary>
        /// Returns one graphics_processing_unit
        /// </summary>
        /// <param name="gpuId">The id of the GpuEntity you want to get</param>
        /// <returns>An ActionResult of type GpuEntity</returns>
        [HttpGet("{gpuId}", Name = "GetGpu")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<GpuEntity> GetGpu(int gpuId)
        {
            var gpuEntity = database.Read(gpuId);

            return Ok(gpuEntity);
        }

        /// <summary>
        /// Create one graphics_processing_unit and results 
        /// created graphics_processing_unit
        /// </summary>
        /// <param name="gpuForCreation">The graphics_processing_unit to create</param>
        /// <returns>An ActionResult of type GpuEntity </returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<GpuEntity> CreateGpu([FromBody] GpuEntity gpuForCreation)
        {
            if (database.Read(gpuForCreation.Id) == null)
            {
                return UnprocessableEntity();
            }

            database.Create(gpuForCreation);
            return CreatedAtRoute("GetGpu", new { gpuId = gpuForCreation.Id }, gpuForCreation);
        }
    }
}
