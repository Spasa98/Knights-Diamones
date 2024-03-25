using BLL.Services.Contracts;
using DAL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable

namespace knights_and_diamonds.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CardController : ControllerBase
	{
		private readonly ICardService _cardService;
		public CardController(ICardService cardService)
		{
			this._cardService = cardService;
		}

        [Authorize(Roles = "Admin")]
        [Route("AddCard")]
		[HttpPost]
		public async Task<IActionResult> AddCard(CardDTO card)
		{
			try
			{
				await this._cardService.AddCard(card);
				return Ok();
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GetCard")]
		[HttpGet]
		public async Task<IActionResult> GetCard(int id)
		{
			try
			{
				if(id > 0) {
					var card=await this._cardService.GetCard(id);
					if (card != null)
					{
						return new JsonResult(card);
					}
					else
					{
						return NotFound("Card with this id doesnt exist");
					}
				}
				else
				{
					return BadRequest("ID must be bigger than 0");
				}
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

		[Route("GetCardByName")]
		[HttpGet]
		public async Task<IActionResult> GetCardByName(string name)
		{
			try
			{
				return new JsonResult(this._cardService.FindCardByName(name).FirstOrDefault());
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

        [Authorize(Roles = "Admin")]
        [Route("DeleteCard/{cardID}")]
		[HttpDelete]
		public async Task<IActionResult> DeleteCard(int cardID)
		{
			try
			{
				await this._cardService.RemoveCard(cardID);
				return Ok(cardID);

			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}

        [Authorize(Roles = "Admin")]
        [Route("UpdateCard")]
		[HttpPut]
		public async Task<IActionResult> UpdateCard([FromBody] UpdateCardDTO card)
		{
			try
			{
				if (card != null)
				{
					await this._cardService.UpdateCard(card);
				}
				else 
				{
					return NotFound("This card doesnt exist");
				}
				return Ok(card);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

/*        [Authorize(Roles = "Admin")]
        [Route("AddCardType")]
		[HttpPost]
		public async Task<IActionResult> AddCardType([FromBody] CardType type)
		{
			try
			{
				this._context.CardTypes.Add(type);
				await this._context.SaveChangesAsync();

				return Ok(type);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}*/

        [Route("GetAllCards")]
        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            try
            {
                var cards=await this._cardService.GetAllCards();

                return Ok(cards);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
		[Route("GetFillteredCards")]
		[HttpGet]
		public async Task<IActionResult> GetFillteredCards(string? typeFilter = "", string? nameFilter = "", string? sortOrder = "",int pageNumber=1,int pageSize=10)
		{
			#pragma warning disable
			try
			{
				var cards = await this._cardService.GetFillteredAndOrderedCards(typeFilter,sortOrder,nameFilter,pageNumber,pageSize);
				return Ok(cards);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}
		[Route("CardCount")]
		[HttpGet]
		public async Task<IActionResult> CardCount()
		{
			try
			{
				var counters = await this._cardService.CardCount();
				return Ok(counters);
			}
			catch (Exception e)
			{
				return BadRequest(e);
			}
		}
	}
}