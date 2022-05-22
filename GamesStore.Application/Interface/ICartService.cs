using GamesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application.Interface
{
    public interface ICartService
    {
        Cart GetGames(Guid userId);
        bool AddGame(Guid userId, Guid gameId);
        bool RemoveGame(Guid userId, Guid gameId);
    }
}
