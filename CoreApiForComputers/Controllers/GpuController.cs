using Microsoft.AspNetCore.Mvc;

namespace CoreApiForComputers.Controllers
{
    /// <summary>
    /// Controller for graphics processing unit
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/gpus")]
    [Produces("application/xml")]
    public class GpuController : ControllerBase
    {

    }
}
