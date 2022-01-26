using AutoMapper;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repository;
        private readonly ILibrariesRepository librariesRepository;
        private readonly IMapper mapper;

        public UserController(IUserRepository repository,ILibrariesRepository librariesRepository, IMapper mapper)
        {
            this.repository = repository;
            this.librariesRepository = librariesRepository;
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
            GetGamesList(id);
            if (id == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("GetGameList/{id}")]
        public IActionResult GetGamesList(int id)
        {
            var games = repository.GetGames(id);

            if (id == null)
                return NotFound();

            return Ok(games);
        }

        /// <remarks>
        /// DayOfBirth Format : dd/MM/yyyy,
        /// </remarks>
        [HttpPost]
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
        public IActionResult UpdateUser(int id, UpdateUserInputModel model)
        {
            var user = repository.GetUserById(id);

            if (user == null)
                return NotFound();

            user.Update(model.name, model.gamerTag, model.password);
            repository.UpdateUsuario(user);

            return NoContent();
        }

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = repository.GetUserById(id);
            if (user == null)
                return NotFound();

            repository.DeleteUsuario(user);

            return NoContent();
        }
    }
}
