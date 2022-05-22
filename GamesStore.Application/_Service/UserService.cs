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
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
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

        public List<User> GetAll()
        {
            var users = repository.GetAll();

            if (users.Count() == 0)
                throw new Exception("Nenhum usuário encontrado");

            return users.ToList();
        }

        public User GetById(Guid id)
        {
            var user = repository.GetUserById(id);
            if (user == null)
                throw new Exception("Nenhum usuário encontrado");

            return user;
        }

        public List<Games> GetGames(Guid id)
        {
            var games = repository.GetGames(id);

            if (games == null)
                throw new Exception("Nenhum jogo encontrado");

            return games.ToList();
        }

        public bool PostUser(AddUserInputModel model)
        {
            var user = mapper.Map<User>(model);
            user.Password = EncryptPassword(user.Password);

            var emailExisits = repository.GetUsuarioByEmail(user.Email);
            var nickNameExists = repository.GetUsuarioByNickName(user.GamerTag);

            if (emailExisits != null)
                throw new Exception("Este usuario ja está cadastrado!");
            if (nickNameExists != null)
                throw new Exception("Este NickName ja existe!");

            //var sendEmail = SendEmailAsync(model.email);
            //if(sendEmail == false)
            //    throw new Exception("Erro ao enviar o email");

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
        }

        public bool PutUser(Guid userId, UpdateUserInputModel model)
        {
            var user = repository.GetUserById(userId);

            if (user == null)
                throw new Exception("Nenhum usuário encontrado");

            var newPassword = EncryptPassword(model.password);

            user.Update(model.name, model.gamerTag, newPassword);
            repository.UpdateUsuario(user);

            return true;
        }

        public bool DeleteUser(Guid id)
        {
            var user = repository.GetUserById(id);
            if (user == null)
                throw new Exception("Nenhum usuário encontrado");

            repository.DeleteUsuario(user);

            return true;
        }

        public UserAuthenticateResponseViewModel Authenticate(UserAuthenticateRequestViewModel user)
        {
            if (string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                throw new Exception("Email/Senha são obrigatórios.");

            user.Password = EncryptPassword(user.Password);

            User _user = repository.GetUsuarioByEmail(user.Email.ToLower());
            if (user.Password != _user.Password)
                throw new Exception("Senha Incorreta!");

            if (_user == null)
                throw new Exception("Nenhum Usuário encontrado");

            return new UserAuthenticateResponseViewModel(_user, TokenServices.GeneratingToken(_user));
        }

        private string EncryptPassword(string password)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();

            byte[] encryptedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var caracter in encryptedPassword)
            {
                stringBuilder.Append(caracter.ToString("X2"));
            }

            return stringBuilder.ToString();
        }

        //public bool SendEmailAsync(string email, string subject, string body)
        //{
        //    string FromMail = "testsendemail90@gmail.com";
        //    string FromPassword = ".NetEmail";

        //    MailMessage Message = new MailMessage();
        //    Message.From = new MailAddress(FromMail);
        //    Message.Subject = subject;
        //    Message.To.Add(new MailAddress(email));
        //    Message.Body = "<html><body> " + body + " </body></html>";
        //    Message.IsBodyHtml = true;

        //    var smtpClient = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(FromMail, FromPassword),
        //        EnableSsl = true
        //    };

        //    smtpClient.Send(Message);

        //    return true;
        //}
    }
}
