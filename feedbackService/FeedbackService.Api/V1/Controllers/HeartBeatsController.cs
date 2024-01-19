using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FeedbackService.Api.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Produces("application/json")] //Here you are telling that only application/json support
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class HeartBeatsController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Task<ActionResult<bool>> PingAsync()
        {
            return Task.FromResult<ActionResult<bool>>(Ok(true));
        }
    }
}