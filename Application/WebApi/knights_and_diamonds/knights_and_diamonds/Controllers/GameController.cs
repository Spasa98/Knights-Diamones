using BLL.Services.Contracts;
using DAL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace knights_and_diamonds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
		struct Field
		{
			public FieldDTO PlayerField { get; set; }
			public EnemiesFieldDTO EnemiesField { get; set; }
		}
        private readonly IGameService _gameService;	
		private readonly ITurnService _turnService;

		public GameController(IGameService gameService,ITurnService turnService)
		{
			this._gameService = gameService;
			this._turnService = turnService;

		}

		[Route("GetGame/{gameID}/{userID}")]
		[HttpGet]
		public async Task<IActionResult> GetGame(int gameID, int userID)
		{
			try
			{
				var game = await this._gameService.GetGame(gameID, userID);
				return Ok(game);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetStartingField/{playerID}/{enemiesPlayerID}")]
		[HttpGet]
		public async Task<IActionResult> GetStartingField(int playerID,int enemiesPlayerID)
		{
			try
			{
				var field = new Field();
				
				var playersField = await this._gameService.GetPlayersField(playerID);
				var f = await this._gameService.GetPlayersField(enemiesPlayerID);
				var enemiesField = this._gameService.GetEneiesField(f);

				field.PlayerField = playersField;
				field.EnemiesField = enemiesField;

				return Ok(field);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetEnemiesField/{playerID}")]
		[HttpGet]
		public async Task<IActionResult> GetEnemiesField(int playerID)
		{
			try
			{
				var field = await this._gameService.GetPlayersField(playerID);
				var enemiesField = this._gameService.GetEneiesField(field);
				return Ok(enemiesField);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetTurnInfo/{gameID}/{playerID}")]
		[HttpGet]
		public async Task<IActionResult> GetTurnInfo(int gameID,int playerID)
		{
			try
			{
				var turnInfo = await this._turnService.GetTurnInfo(gameID, playerID);
				return Ok(turnInfo);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetGrave/{gameID}")]
		[HttpGet]
		public async Task<IActionResult> GetGrave(int gameID)
		{
			try
			{
				var grave = await this._gameService.GetGamesGrave(gameID);
				return Ok(grave);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetHand/{gameID}")]
		[HttpGet]
		public async Task<IActionResult> GetGameGroup(int gameID)
		{
			try
			{
				var gg=await this._gameService.GameGroup(gameID);
				return Ok(gg);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

        [Route("GetGraveByType")]
        [HttpGet]
        public async Task<IActionResult> GetGraveByType(int gameID, string? typeFilter = "",int pageNumber = 1, int pageSize = 10)
        {
            try
            {
				#pragma warning disable
                var graveStats = await this._gameService.GetGrave(gameID,typeFilter,pageSize,pageNumber);
                return Ok(graveStats);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
