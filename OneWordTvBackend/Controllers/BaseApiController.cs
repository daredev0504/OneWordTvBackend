using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OneWordTvBackend.Controllers
{
    /// <summary>
    /// Base Controller
    /// </summary>
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }
}
