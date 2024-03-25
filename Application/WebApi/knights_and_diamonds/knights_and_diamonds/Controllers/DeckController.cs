using Microsoft.AspNetCore.Mvc;
using BLL.Services.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace knights_and_diamonds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeckController : ControllerBase
    {
        private readonly IDeckService _deckService;
        public DeckController(IDeckService deckService)
        {
            this._deckService = deckService;
        }

        [Route("AddDeck/{userID}")]
        [HttpPost]
        public async Task<IActionResult> AddDeck(int userID)
        {
            try
            {
                var d = await this._deckService.AddDeck(userID);
                return Ok(d);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("SetMainDeck")]
        [HttpPut]
        public async Task<IActionResult> SetMainDeck(int userID, int deckID)
        {
            try
            {
                if (userID <= 0)
                {
                    return BadRequest("UserID must be bigger then 0");
                }
                if (deckID <= 0)
                {
                    return BadRequest("DeckID must be bigger then 0");
                }
                var user = await this._deckService.SetMainDeckID(userID, deckID);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [Route("GetDeck/{userID}")]
        [HttpGet]
        public async Task<IActionResult> GetDeck(int userID)
        {
            try
            {
                if (userID <= 0)
                {
                    return BadRequest("ID must be bigger than 0");
                }
                var c = await this._deckService.GetCardsFromDeck(userID);
                return new JsonResult(c);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
		
        [Authorize]
		[Route("AddCardToDeck/{cardID}/{deckID}")]
        [HttpPost]
        public async Task<IActionResult> AddCardToDeck(int cardID, int deckID)
        {
            try
            {
				var userId = int.Parse(User.FindFirstValue("ID"));
                if (await this._deckService.UserOwnesDeck(userId, deckID))
                {
                    await this._deckService.AddCardToDeck(cardID, deckID);
                }
				else
				{
					return Unauthorized("User dose not own this deck");
				}
				return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
		[Authorize]
		[Route("RemoveCardFromDeck/{cardID}/{deckID}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveCardFromDeck(int cardID, int deckID)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue("ID"));
                if (await this._deckService.UserOwnesDeck(userId, deckID))
                {
                    await this._deckService.RemoveCardFromDeck(cardID, deckID);
                }
                else 
                {
					return Unauthorized("User dose not own this deck");
				}
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("CardCounter/{deckID}/{userID}")]
        [HttpGet]
        public async Task<IActionResult> CardCounter(int deckID, int userID)
        {
            try
            {
                if (userID <= 0 || deckID <= 0)
                {
                    return BadRequest("ID must be bigger than 0");
                }
                var count = await this._deckService.CardCounter(deckID, userID);
                return new JsonResult(count);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}