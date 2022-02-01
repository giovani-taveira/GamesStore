using GamesStore.Entities;
using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application.Models._Authentication
{
    public class UserAuthenticateResponseViewModel
    {
        public UserAuthenticateResponseViewModel(User user, string token)
        {
            this.User = user;
            this.Token = token;
        }

        public User User { get; set; }
        public string Token { get; set; }

    }
}
