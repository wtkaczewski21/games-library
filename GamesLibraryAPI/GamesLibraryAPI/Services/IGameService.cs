using GamesLibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesLibraryAPI.Services
{
    public interface IGameService
    {
        Task<List<Game>> GetAllGames();
        Task<Game> GetGameById(int id);
        Task<Game> AddGame(Game game);
        Task<Game> UpdateGame(int id, Game game);
        Task<List<Game>> DeleteGame(int id);
    }
}
