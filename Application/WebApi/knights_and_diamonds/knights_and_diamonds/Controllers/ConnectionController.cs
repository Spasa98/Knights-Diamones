using Microsoft.AspNetCore.Mvc;
using BLL.Services.Contracts;
#pragma warning disable

namespace knights_and_diamonds.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ConnectionController : ControllerBase
	{

		private readonly IConnectionService _connectionService;

		public ConnectionController(IConnectionService connectionService)
		{
			this._connectionService = connectionService;
		}

		[HttpPost]
		[Route("AddOnlineUser")]
		public async Task<IActionResult> AddOnlineUser(int userID, string connID)
		{
			try
			{
				this._connectionService.AddOnlineUser(userID, connID);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet]
		[Route("GetConnectionByID")]
		public async Task<IActionResult> GetConnectionByID(int id)
		{
			var c =  this._connectionService.GetConnectionByUser(id);
			return new JsonResult(c);

		}
		[HttpGet]
		[Route("GetOnlineUsers")]
		public async Task<IActionResult> GetOnlineUsers()
		{
			try
			{
				var c = await this._connectionService.GetOnlineUsers();

				return new JsonResult(c);
			}
			catch(Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}