using GamesStore.Application.Interface;
using GamesStore.Application.Models._Authentication;
using GamesStore.Authentication.Services;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application._Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }
        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            User _user = repository.GetUsuarioByEmail(user.Email.ToLower());
            if (_user == null)
                throw new Exception("User not found");

            return new UserAuthenticateResponseViewModel(_user, TokenServices.GeneratingToken(_user));
        }
    }
}
