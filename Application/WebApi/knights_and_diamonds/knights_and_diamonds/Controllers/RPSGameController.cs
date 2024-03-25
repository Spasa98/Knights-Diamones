using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using DAL.DTOs;

namespace knights_and_diamonds.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class RPSGameController : ControllerBase
	{
		private readonly IRPSGameService _rpsGameService;
		private readonly IUserService _userService;

		public RPSGameController(IRPSGameService rpsGameService,IUserService userService)
		{
			this._rpsGameService = rpsGameService;
			this._userService = userService;
		}

		[Route("NewLobby")]
		[HttpPost]
		public async Task<IActionResult> NewLobby(int userID, int challengedUserID)
		{
			#pragma warning disable
			try
			{
				if (userID == challengedUserID)
				{
					return BadRequest("Users IDs are the same, you cannot play against yourself!!");
				}

				var user = await this._userService.GetUserByID(userID);
				var challengedUser = await this._userService.GetUserByID(challengedUserID);

                if (user == null || challengedUser == null)
                {
					return NotFound("User does not exists.");
                }

                var player1 = new OnlineUserDto(user.ID, user.Name, user.SurName, user.UserName);
				var player2 = new OnlineUserDto(challengedUser.ID, challengedUser.Name, challengedUser.SurName, challengedUser.UserName);

				if (user != null && challengedUser!=null)
				{
					var lobbyID = this._rpsGameService.NewLobby(player1, player2);
					return Ok(lobbyID);
				}
				else 
				{
					return NotFound("User is not found");
				}
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("StartGame/{lobbyID}")]
		[HttpPost]
		public async Task<IActionResult> StartGame(int lobbyID)
		{
			try
			{
				var game = await this._rpsGameService.StartGame(lobbyID);
				return Ok(game);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetGames")]
		[HttpGet]
		public async Task<IActionResult> GetGames()
		{
			try
			{
				var games =  this._rpsGameService.GetGames();
				return new JsonResult(games);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[Route("GetRPSGame/{gameID}/{userID}")]
		[HttpGet]
		public async Task<IActionResult> GetGame(int gameID,int userID)
		{
			try
			{
				var game = await this._rpsGameService.GetGame(gameID,userID);
				return Ok(game);
				
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
		[Route("GetPlayerMove/{playerID}")]
		[HttpGet]
		public async Task<IActionResult> GetPlayerMove(int playerID)
		{
			try
			{
				var move=await this._rpsGameService.GetPlayersMove(playerID);
				return Ok(move);

			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetLobies")]
		[HttpGet]
		public async Task<IActionResult> GetLobies(int userID)
		{
			try
			{
				var user = await this._userService.GetUserByID(userID);
				if (user != null)
				{
					var games = this._rpsGameService.LobbiesPerUser(userID);
					return new JsonResult(games);
				}
				else 
				{
					return BadRequest("User is not found");
				}
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[Route("DenyGame/{lobbyID}")]
		[HttpDelete]
		public async Task<IActionResult> DenyGame(int lobbyID)
		{
            try
            {
				var game = this._rpsGameService.DenyGame(lobbyID);
				return Ok(game);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("Redirect")]
        [HttpGet]
        public async Task<IActionResult> Redirect(int gameID)
        {
            try
            {
                var userIDs = await this._rpsGameService.RedirectToGame(gameID);
                return Ok(userIDs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		[Route("PlayMove/{playerID}/{moveName}")]
		[HttpPut]
		public async Task<IActionResult> PlayMove(int playerID, string moveName)
		{
            try
            {
                await this._rpsGameService.PlayMove(playerID, moveName);
				return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("CheckRPSWinner")]
        [HttpGet]
        public async Task<IActionResult> CheckRPSWinner(int gameID)
        {
            try
            {
				var winner = await this._rpsGameService.CheckRPSWinner(gameID);
                return Ok(winner);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		[Route("GetPlayer/{gameID}/{userID}")]
		[HttpGet]
		public async Task<IActionResult> GetPlayer(int gameID, int userID)
		{
			try
			{
				var player = await this._rpsGameService.GetPlayer(gameID, userID);
				return Ok(player);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("RemoveUserFromUsersInGame/{userID}")]
		[HttpDelete]
		public async Task<IActionResult> RemoveUserFromUsersInGame(int userID)
		{
			try
			{
				this._rpsGameService.RemoveUserFromUsersInGame(userID);
				return Ok();
			}
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
