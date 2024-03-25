using BLL.Services.Contracts;
using BLL.Services;
using DAL.DataContext;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using DAL.DTOs;

namespace knights_and_diamonds.Controllers
{
    public class LoginController : ControllerBase
    {
		private readonly KnightsAndDiamondsContext _context;
		private readonly IConfiguration _config;
		private readonly ILoginService _loginService;
		private readonly IConnectionService _connectionService;

		public LoginController(
			KnightsAndDiamondsContext context, 
			IConfiguration config,
			IConnectionService connectionService)
        {
			this._config = config;
			this._context = context;
			this._connectionService = connectionService;
			this._loginService = new LoginService(this._context, this._config);
		}

		public static long CheckLoginToken(string token) 
        {
			var handler = new JwtSecurityTokenHandler();
			var jwtSecurityToken = handler.ReadJwtToken(token);
			var tokenExp = jwtSecurityToken.Claims.First(claim => claim.Type.Equals("exp")).Value;
			var ticks = long.Parse(tokenExp);
            return ticks;
        }
		[HttpGet]
		[Route("checkLoginToken")]
		#pragma warning disable
		public async Task<IActionResult> CheckTokenIsValid(string token)
		{
			var tokenTicks = CheckLoginToken(token);
			var tokenDate = DateTimeOffset.FromUnixTimeSeconds(tokenTicks).UtcDateTime;

			var now = DateTime.Now.ToUniversalTime();
            var valid = tokenDate;
			if (valid >= now)
            {
				return Ok(true);
			}
            else
            {
                return Ok(false) ;
            }
		}
		[HttpPost]
        [Route("LogIn")]
        public async Task<IActionResult> LogIn([FromBody] UserInfoDTO userInfo)
        {
            try
            {
				var t = await this._loginService.Login(userInfo);
				return Ok(t);
                
            }
            catch(Exception e) 
            {
                return BadRequest(e.Message);
            }
        }
		[HttpDelete]
		[Route("LogOut")]
		public async Task<IActionResult> LogOut(int userID)
		{
            try
            {
				this._connectionService.RemoveUserFromOnlineUsers(userID);
                return Ok();
            }
            catch(Exception e)
			{
                return BadRequest(e.Message);
            }
		}
	
		[HttpGet]
		[Route("GetConnectionPerUser")]
		public async Task<IActionResult> GetConnectionPerUser(int UserID)
		{
			try
			{
				var c =  this._connectionService.GetConnectionByUser(UserID);

				return new JsonResult(c);
			}
			catch
			{
				return BadRequest();
			}
		}

		
	}
}
