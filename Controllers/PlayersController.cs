using CQRSDemo1.Data;
using CQRSDemo1.Features.Players.CreatePlayer;
using CQRSDemo1.Features.Players.GetPlayerById;
using CQRSDemo1.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRSDemo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly ISender _sender;

        public PlayersController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreatePlayer(CreatePlayerCommand command)
        {
            var playerId = await _sender.Send(command);

            return Ok(playerId);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(int id) {
            var player = await _sender.Send(new GetPlayerByIdQuery {Id = id});

            if (player == null) {
                return NotFound(new { message = "Player not found!" });
            }

            return Ok(player);
        }
    }
}
