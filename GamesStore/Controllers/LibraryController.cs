using GamesStore.Application.Interface;
using GamesStore.Authentication.Services;
using GamesStore.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesStore.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        [HttpGet]
        public IActionResult GetGamesFromLibrary()
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            return Ok(libraryService.GetGames(_userId));
        }

        [HttpPost("{gameId}")]
        public IActionResult AddGameOnLibrary(Guid gameId)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            return Ok(libraryService.AddGame(_userId, gameId));
        }
    }
}
