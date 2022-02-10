using AutoMapper;
using GamesStore.Application.Interface;
using GamesStore.Authentication.Services;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IO;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(gameService.GetAll());
        }

        [HttpGet("GetById")]
        public IActionResult GetById()
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));

            return Ok(gameService.GetById(_userId));
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(gameService.GetByName(name));
        }

        [HttpGet("GetByGender/{gender}")]
        public IActionResult GetByGender(string gender)
        {
            return Ok(gameService.GetByGender(gender));
        }

        /// <remarks>
        /// ReleaseDate Format : yyyy-MM-ddT00:00:00
        /// </remarks>
        [HttpGet("GetByReleaseDate/{releaseDate}")]
        public IActionResult GetByReleaseDate(DateTime releaseDate)
        {
            return Ok(gameService.GetByReleaseDate(releaseDate));
        }

        [HttpGet("GetByPrice/{price}")]
        public IActionResult GetByPrice(decimal price)
        {
            return Ok(gameService.GetByPrice(price));
        }

        /// <remarks>
        /// ReleaseDate Format : dd/MM/yyyy
        /// </remarks>
        [HttpPost("{img}")]
        public IActionResult AddNewGame(AddGameInputModel model)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));

            return Ok(gameService.AddNewGame(_userId, model));
        }

        [HttpPut("{gameId}")]
        public IActionResult UpdateGame(Guid gameId, UpdateGameInputModel model)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            gameService.UpdateGame(gameId, _userId, model);

            return NoContent();
        }

        [HttpDelete("{gameId}")]
        public IActionResult DeleteGame(Guid gameId)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            gameService.DeleteGame(gameId, _userId);

            return NoContent();
        }
    }
}
