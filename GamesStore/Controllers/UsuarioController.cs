using AutoMapper;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository repository;
        private readonly IBibliotecasRepository bibliotecasRepository;
        private readonly IMapper mapper;

        public UsuarioController(IUsuarioRepository repository,IBibliotecasRepository bibliotecasRepository, IMapper mapper)
        {
            this.repository = repository;
            this.bibliotecasRepository = bibliotecasRepository;
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

        [HttpPost]
        public IActionResult AddNewUser(AddUsuarioInputModel model)
        {
            var user = mapper.Map<Usuario>(model);

            var emailExisits = repository.GetUsuarioByEmail(user.Email);
            var nickNameExists = repository.GetUsuarioByNickName(user.NickName);
            
            if (emailExisits != null )
                return BadRequest("Este usuario ja está cadastrado!");
            if (nickNameExists != null)
                return BadRequest("Este NickName ja existe!");

            repository.AddUsuario(user);

            var cart = new Carrinho();
            cart.UsuarioId = user.UsuarioId;
            bibliotecasRepository.CreateCart(cart);

            var wishList = new ListaDeDesejos();
            wishList.UsuarioId = user.UsuarioId;
            bibliotecasRepository.CreateWishList(wishList);

            var library = new Biblioteca();
            library.UsuarioId = user.UsuarioId;
            bibliotecasRepository.CreateLibrary(library);


            return CreatedAtAction("User", new { userId = user.UsuarioId }, user);
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(int id, UpdateUsuarioInputModel model)
        {
            var user = repository.GetUserById(id);
            //var nickNameExists = repository.GetUsuarioByNickName(model.nickName);

            if (user == null)
                return NotFound();

            //if (nickNameExists != null)
            //    return BadRequest("Este NickName ja existe!");

            user.Update(model.nome, model.nickName, model.senha);
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
