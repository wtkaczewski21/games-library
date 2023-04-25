using GamesLibraryAPI.Data;
using GamesLibraryAPI.Models;
using GamesLibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _service;
        public GamesController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> GetAllGames()
        {
            var games = await _service.GetAllGames();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGameById(int id)
        {
            var game = await _service.GetGameById(id);
            if (game is null)
                return NotFound("Sorry, this game doesn't exist.");

            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<Game>> AddGame(Game game)
        {
            await _service.AddGame(game);
            return Ok(game);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> UpdateGame(int id, Game game)
        {
            var updatedGame = await _service.UpdateGame(id, game);
            if (updatedGame is null)
                return NotFound("Sorry, this game doesn't exist.");

            return Ok(updatedGame);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Game>>> DeleteGame(int id)
        {
            var game = await _service.DeleteGame(id);
            if (game is null)
                return NotFound("Sorry, this game doesn't exist.");

            return Ok();
        }
    }
}
