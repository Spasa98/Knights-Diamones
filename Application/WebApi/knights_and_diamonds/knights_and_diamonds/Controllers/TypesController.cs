using BLL.Services.Contracts;
using BLL.Services;
using DAL.DataContext;
using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using BLL.Strategy.Context;
using BLL.Strategy;

namespace knights_and_diamonds.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class TypesController : ControllerBase
	{
		private readonly KnightsAndDiamondsContext _context;
		private readonly IEffectService _effectService;
		public TypesController(KnightsAndDiamondsContext context, IEffectService effectService)
		{
			this._context = context;
			this._effectService = effectService;
		}

		[Route("AddEffectType")]
		[HttpPost]
		public async Task<IActionResult> AddEffectType([FromBody] EffectType type)
		{
			try
			{
				this._context.EffectTypes.Add(type);
				await this._context.SaveChangesAsync();

				return Ok(type);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[Route("GetEffectTypes")]
		[HttpGet]
		public async Task<IActionResult> GetEffectTypes()
		{
			try
			{
				var et = await this._effectService.GetEffectTypes();
				return Ok(et);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

        [Route("GetEffectTypeByID/{effectTypeID}")]
        [HttpGet]
        public async Task<IActionResult> GetEffectTypeByID(int effectTypeID)
        {
            try
            {
				var et = await this._effectService.GetEffectTypeByID(effectTypeID);
                return Ok(et);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("GetCardTypes")]
		[HttpGet]
		public async Task<IActionResult> GetCardTypes()
		{
			try
			{
				var cardTypes = await this._context.CardTypes?.ToListAsync();

				return Ok(cardTypes);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

        [Route("GetCardTypeByID/{cardTypeID}")]
        [HttpGet]
        public async Task<IActionResult> GetCardTypeByID(int cardTypeID)
        {
            try
            {
				var cardTypes = await this._context.CardTypes.FindAsync(cardTypeID);
                return Ok(cardTypes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

	}

}
