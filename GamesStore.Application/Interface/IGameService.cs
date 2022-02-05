using GamesStore.Entities;
using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application.Interface
{
    public interface IGameService
    {
        List<Games> GetAll();
        Games GetById(int id);
        List<Games> GetByName(string name);
        List<Games> GetByGender(string gender);
        List<Games> GetByReleaseDate(DateTime releaseDate);
        List<Games> GetByPrice(decimal price);
        bool AddNewGame(int userId, AddGameInputModel model);
        bool UpdateGame(int gameId, int userId, UpdateGameInputModel model);
        bool DeleteGame(int gameId, int userId);
    }
}
