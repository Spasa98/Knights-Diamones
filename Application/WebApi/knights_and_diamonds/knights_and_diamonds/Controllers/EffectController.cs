using BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace knights_and_diamonds.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EffectController : ControllerBase
	{
		private readonly IEffectService _effectService;
		public EffectController(IEffectService effectService)
		{
			this._effectService = effectService;
		}

		[Route("GetAreaOfClicking/{effectTypeID}")]
		[HttpGet]
		public async Task<IActionResult> GetAreaOfClicking(int effectTypeID)
		{
			try
			{
				var area = await this._effectService.GetAreaOfClickingAfterPlayCard(effectTypeID);
				return Ok(area);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

	}
}
