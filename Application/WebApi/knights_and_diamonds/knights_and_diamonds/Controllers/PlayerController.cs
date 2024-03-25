using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace knights_and_diamonds.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PlayerController : ControllerBase
	{
		private readonly IPlayerService _playerService;
		public PlayerController(IPlayerService playerService)
		{
			this._playerService = playerService;
		}

		[Route("GetPlayer/{playerID}")]
		[HttpGet]
		public async Task<IActionResult> GetPlayer(int playerID)
		{
			try
			{
				var player = await this._playerService.GetPlayer(playerID);
				return Ok(player);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}


		[Route("SetStatus/{playerID}")]
		[HttpGet]
		public async Task<IActionResult> SetStatus(int playerID)
		{
			try
			{
				var player = await this._playerService.GetPlayer(playerID);
				await this._playerService.SetGameStarted(player);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("Draw/{playerID}")]
		[HttpGet]
		public async Task<IActionResult> Draw(int playerID)
		{
			try
			{
				return new JsonResult(await this._playerService.Draw(playerID));
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[Route("GetNumberOfCardsInDeck/{playerID}")]
		[HttpGet]
		public async Task<IActionResult> GetNumberOfCardsInDeck(int playerID)
		{
			try
			{
				if (playerID <= 0)
				{
					return BadRequest("Error,wrong playerID");
				}
				var nuc = await this._playerService.GetNumberOfCardsInDeck(playerID);
				return Ok(nuc);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetPlayersHand/{playerID}")]
		[HttpGet]
		public async Task<IActionResult> GetPlayersHand(int playerID)
		{
			try
			{
				var card = await this._playerService.GetPlayersHand(playerID);
				return Ok(card);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

        [Route("SetFieldPosition/{playerID}/{position}")]
        [HttpGet]
        public async Task<IActionResult> SetFieldPosition(int playerID, bool position)
		{
			try
			{
				await this._playerService.SetFieldPosition(playerID, position);
				return Ok();
			}
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
