using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Http;
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
        Games GetById(Guid id);
        List<Games> GetByName(string name);
        List<Games> GetByGender(string gender);
        List<Games> GetByReleaseDate(DateTime releaseDate);
        List<Games> GetByPrice(decimal price);
        bool AddNewGame(Guid userId, AddGameInputModel model);
        bool UpdateGame(Guid gameId, Guid userId, UpdateGameInputModel model);
        bool DeleteGame(Guid gameId, Guid userId);
    }
}
