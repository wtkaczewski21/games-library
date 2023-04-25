using GamesLibraryAPI.Data;
using GamesLibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesLibraryAPI.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
        public GameService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Game> AddGame(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<List<Game>> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
                return null;

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return await _context.Games.ToListAsync();
        }

        public async Task<List<Game>> GetAllGames()
        {
            var games = await _context.Games.ToListAsync();
            return games;
        }

        public async Task<Game> GetGameById(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game is null)
                return null;

            return game;
        }

        public async Task<Game> UpdateGame(int id, Game game)
        {
            var updatedGame = await _context.Games.FindAsync(id);
            if (updatedGame is null)
                return null;

            updatedGame.Title = game.Title;
            updatedGame.Category = game.Category;
            updatedGame.ReleaseDate = game.ReleaseDate;

            await _context.SaveChangesAsync();
            return (updatedGame);
        }
    }
}
