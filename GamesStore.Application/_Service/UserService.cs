using AutoMapper;
using GamesStore.Application.Interface;
using GamesStore.Application.Models._Authentication;
using GamesStore.Authentication.Services;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
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
        private readonly IMapper mapper;
        private readonly ILibrariesRepository librariesRepository;

        public UserService(IUserRepository repository, IMapper mapper, ILibrariesRepository librariesRepository)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.librariesRepository = librariesRepository;
        }
        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            User _user = repository.GetUsuarioByEmail(user.Email.ToLower());
            if (_user == null)
                throw new Exception("Nenhum Usuário encontrado");

            return new UserAuthenticateResponseViewModel(_user, TokenServices.GeneratingToken(_user));
        }

        public List<User> GetAll()
        {
            var users = repository.GetAll();

            if (users.Count() == 0)
                throw new Exception("Nenhum usuário encontrado");

            return users.ToList();
        }

        public User GetById(int id)
        {
            var user = repository.GetUserById(id);
            if (user == null)
                throw new Exception("Nenhum usuário encontrado");

            return user;
        }

        public List<Games> GetGames(int id)
        {
            var games = repository.GetGames(id);

            if (games == null)
                throw new Exception("Nenhum jogo encontrado");

            return games.ToList();
        }

        public bool PostUser(AddUserInputModel model)
        {
            var user = mapper.Map<User>(model);

            var emailExisits = repository.GetUsuarioByEmail(user.Email);
            var nickNameExists = repository.GetUsuarioByNickName(user.GamerTag);

            if (emailExisits != null)
                throw new Exception("Este usuario ja está cadastrado!");
            if (nickNameExists != null)
                throw new Exception("Este NickName ja existe!");

            try
            {
                repository.AddUsuario(user);

                var cart = new Cart(user.UserId);
                librariesRepository.CreateCart(cart);

                var wishList = new WishList(user.UserId);
                librariesRepository.CreateWishList(wishList);

                var library = new Library(user.UserId);
                librariesRepository.CreateLibrary(library);
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro ao cadastrar um novo usuário");
            }

            return false;
        }

        public bool PutUser(int userId, UpdateUserInputModel model)
        {
            var user = repository.GetUserById(userId);

            if (user == null)
                throw new Exception("Nenhum usuário encontrado");

            user.Update(model.name, model.gamerTag, model.password);
            repository.UpdateUsuario(user);

            return true;
        }

        public bool DeleteUser(int id)
        {
            var user = repository.GetUserById(id);
            if (user == null)
                throw new Exception("Nenhum usuário encontrado");

            repository.DeleteUsuario(user);

            return true;
        }
    }
}
