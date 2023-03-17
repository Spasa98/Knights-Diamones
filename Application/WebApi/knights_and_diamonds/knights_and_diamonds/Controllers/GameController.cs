﻿using BLL.Services;
using BLL.Services.Contracts;
using DAL.DataContext;
using DAL.DesignPatterns;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace knights_and_diamonds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly KnightsAndDiamondsContext context;
        public IGameService _gameservice { get; set; }
        public IPlayerService _playerservice { get; set; }
        public GameController(KnightsAndDiamondsContext context)
        {
            this.context = context;
            this._gameservice = new GameService(this.context);
            this._playerservice = new PlayerService(this.context);
        }

        /*[Route("StartGame/{player1ID}/{player2ID}")]
        [HttpPost]
        public async Task<IActionResult> StartGame(int player1ID, int player2ID)
        {
            try
            {
                var game = await this._gameservice.StartGame(player1ID, player2ID);
                return Ok(game);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [Route("SetShuffledDeck/{playerID}")]
        [HttpPut]
        public async Task<IActionResult> SetShuffledDeck(int playerID)
        {
            try
            {
                await this._gameservice.SetShuffledDeck(playerID);
                return Ok("Deck is shuffled.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetShuffledDeck/{playerID}")]
        [HttpGet]
        public async Task<IActionResult> GetShuffledDeck(int playerID)
        {
            try
            {
                var shuffledDeck = await this._playerservice.GetShuffledDeck(playerID);
                return Ok(shuffledDeck);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
