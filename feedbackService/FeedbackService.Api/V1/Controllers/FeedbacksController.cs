using FeedbackService.Core.Interfaces.Services;
using FeedbackService.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace FeedbackService.Api.V1.Controllers
{
    [Produces(Application.Json)]
    [Route("api/" + ApiConstants.ServiceName + "/v{api-version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        public readonly IFeedbackService _feedbackService;
        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService ?? throw new ArgumentNullException(nameof(feedbackService));

        }

        [HttpGet(Name = "GetFeedbacks")]
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

            return response != null ? Ok(response) : NotFound();

        }

        [HttpGet("id", Name = "GetFeedbackById")]
        //[Route("getfeedbacks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FeedbackDTO>> GetFeedbackById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await _feedbackService.GetFeedbackByIdAsync(id).ConfigureAwait(false);
            return response != null ? Ok(response) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FeedbackDTO>> CreateFeedback(FeedbackDTO feedbackDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var response = await _feedbackService.CreateFeedbackAsync(feedbackDTO).ConfigureAwait(false);

            return CreatedAtRoute(nameof(GetFeedbackById), new { id = response.Id }, response);
        }

        [HttpDelete("{id}", Name = "DeleteFeedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> DeleteFeedback(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var response = await _feedbackService.DeleteFeedbackAsync(id).ConfigureAwait(false);
            return response ? NoContent() : NotFound();
        }

        [HttpPut("{id}", Name = "UpdateFeedback")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateFeedback(int id, FeedbackDTO feedbackDTO)
        {
            if (!ModelState.IsValid || id <= 0)
            {
                return BadRequest();
            }
            
            var response = await _feedbackService.UpdateFeedbackAsync(id, feedbackDTO).ConfigureAwait(false);
            return response ? Ok(response) : NotFound();
        }

    }
}
