using GamesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application.Interface
{
    public interface ILibraryService
    {
        Library GetGames(int userId);
        bool AddGame(int userId, int gameId);
    }
}
