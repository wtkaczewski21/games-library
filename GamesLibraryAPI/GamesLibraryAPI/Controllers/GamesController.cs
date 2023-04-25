using GamesLibraryAPI.Data;
using GamesLibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GamesLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GamesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGames()
        {
            var games = await _context.Games.ToListAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGameById(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
                return NotFound("Sorry, this game doesn't exist.");

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> AddGame(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return Ok(game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGame(int id, Game game)
        {
            var updatedGame = await _context.Games.FindAsync(id);
            if (updatedGame is null)
                return NotFound("Sorry, this game doesn't exist.");

            updatedGame.Title = game.Title;
            updatedGame.Category = game.Category;
            updatedGame.ReleaseDate = game.ReleaseDate;

            await _context.SaveChangesAsync();
            return Ok(updatedGame);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
                return NotFound("Sorry, this game doesn't exist.");

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return Ok(_context.Games);
        }
    }
}
