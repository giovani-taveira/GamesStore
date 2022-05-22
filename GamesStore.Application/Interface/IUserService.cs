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
        User GetById(Guid id);
        List<Games> GetGames(Guid id);
        bool PostUser(AddUserInputModel model);
        bool PutUser(Guid userId, UpdateUserInputModel model);
        bool DeleteUser(Guid id);
        //bool SendEmailAsync(string email, string subject, string body);
        UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user);
    }
}
