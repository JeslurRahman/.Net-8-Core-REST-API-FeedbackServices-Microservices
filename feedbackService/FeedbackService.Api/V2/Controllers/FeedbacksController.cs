using FeedbackService.Core.Interfaces.Services;
using FeedbackService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackService.Api.V2.Controllers
{
    [Route("api/" + ApiConstants.ServiceName + "/v{api-version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        public readonly IFeedbackService _feedbackService;
        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));
            
        }

        [HttpGet]
        //[Route("getfeedbacks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<FeedbackDTO>>> GetFeedbacks()
        {
            // throw new Exception($"Error while trying to call GetFeedbacks method.");
            var response = await _feedbackService.GetAllFeedbacksAsync().ConfigureAwait(false);
            if(response == null)
            {
                return NoContent();
            }
            return Ok(response);

        }

    }
}
