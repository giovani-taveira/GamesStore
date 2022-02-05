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
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult GetAllUsers()
        {
            return Ok(userService.GetAll());
        }

        [HttpGet("GetUserById/{id}"), AllowAnonymous]
        public IActionResult GetUserById(int id)
        {
            return Ok(userService.GetById(id));
        }

        [HttpGet("GetGameList")]
        public IActionResult GetGamesList()
        {
            int _userId = int.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            return Ok(userService.GetGames(_userId));
        }

        /// <remarks>
        /// DayOfBirth Format : dd/MM/yyyy,
        /// </remarks>
        [HttpPost, AllowAnonymous]
        public IActionResult AddNewUser(AddUserInputModel model)
        {
            return Ok(userService.PostUser(model));
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(UpdateUserInputModel model)
        {
            int _userId = int.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            userService.PutUser(_userId, model);

            return NoContent();
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser()
        {
            int _userId = int.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier).ToString());
            userService.DeleteUser(_userId);

            return NoContent();
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult AuthenticateUser(UserAuthenticateRequestViewModel model)
        {
            return Ok(userService.Authenticate(model));
        }
    }
}
