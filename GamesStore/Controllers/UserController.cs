using AutoMapper;
using GamesStore.Application.Interface;
using GamesStore.Application.Models._Authentication;
using GamesStore.Authentication.Services;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesStore.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly ILibrariesRepository librariesRepository;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserRepository repository,ILibrariesRepository librariesRepository, IUserService userService, IMapper mapper)
        {
            this.repository = repository;
            this.librariesRepository = librariesRepository;
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = repository.GetAll();         

            if (users.Count() == 0)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = repository.GetUserById(id);
            if (id == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("GetGameList")]
        public IActionResult GetGamesList()
        {
            int _userId = int.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            var games = repository.GetGames(_userId);

            if (_userId == null)
                return NotFound();

            return Ok(games);
        }

        /// <remarks>
        /// DayOfBirth Format : dd/MM/yyyy,
        /// </remarks>
        [HttpPost, AllowAnonymous]
        public IActionResult AddNewUser(AddUserInputModel model)
        {
            var user = mapper.Map<User>(model);

            var emailExisits = repository.GetUsuarioByEmail(user.Email);
            var nickNameExists = repository.GetUsuarioByNickName(user.GamerTag);
            
            if (emailExisits != null )
                return BadRequest("Este usuario ja está cadastrado!");
            if (nickNameExists != null)
                return BadRequest("Este NickName ja existe!");

            repository.AddUsuario(user);

            var cart = new Cart(user.UserId);     
            librariesRepository.CreateCart(cart);

            var wishList = new WishList(user.UserId);
            librariesRepository.CreateWishList(wishList);

            var library = new Library(user.UserId);
            librariesRepository.CreateLibrary(library);

            return CreatedAtAction("User", new { userId = user.UserId }, user);
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(UpdateUserInputModel model)
        {
            int _userId = int.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            var user = repository.GetUserById(_userId);

            if (user == null)
                return NotFound();

            user.Update(model.name, model.gamerTag, model.password);
            repository.UpdateUsuario(user);

            return NoContent();
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser()
        {

            int _userId = int.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            
            var user = repository.GetUserById(_userId);
            if (user == null)
                return NotFound();

            repository.DeleteUsuario(user);

            return NoContent();
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult AddNewUser(UserAuthenticateRequestViewModel model)
        {
            return Ok(userService.Authenticate(model));
        }
    }
}
