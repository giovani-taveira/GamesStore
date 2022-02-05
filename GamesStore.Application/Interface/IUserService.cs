using GamesStore.Application.Models._Authentication;
using GamesStore.Entities;
using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application.Interface
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        List<Games> GetGames(int id);
        bool PostUser(AddUserInputModel model);
        bool PutUser(int userId, UpdateUserInputModel model);
        bool DeleteUser(int id);
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);
    }
}
