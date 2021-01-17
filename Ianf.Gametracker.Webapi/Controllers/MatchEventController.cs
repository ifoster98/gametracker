using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Ianf.Gametracker.Services.Interfaces;

namespace Ianf.Gametracker.Webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchEventController : ControllerBase
    {
        private readonly IMatchEventService _matchEventService;

        public MatchEventController(IMatchEventService matchEventService)
        {
            _matchEventService = matchEventService;
        }

        [HttpGet("/LoginWithUserId/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<bool>> LoginWithUserId(int userId)
        {
            var result = await _matchEventService.LoginWithUserId(userId);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> AddNewMatchEventAsync(Ianf.Gametracker.Services.Dto.MatchEvent matchEvent)
        {
            var result = await _matchEventService.AddNewMatchEventAsync(matchEvent);
            ActionResult<int> returnValue = Ok();
            return result.Match(
                Left: (err) => returnValue = BadRequest(err),
                Right: (newMatchEventId) => returnValue = Ok(newMatchEventId)
            );
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllMatchEventAsync(int userId)
        {
            var result = await _matchEventService.GetAllMatchEventsByUserIdAsync(userId);
            return Ok(result);
        }
    }
}