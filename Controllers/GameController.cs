using AutoMapper;
using GamesStore.Application.Interface;
using GamesStore.Authentication.Services;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/game")]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAll(int skip = 0, int take = 5)
        {
            return Ok(await gameService.GetAll(skip, take));
        }

        [HttpGet("GetById/{id}")]
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
        [HttpPost()]
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
