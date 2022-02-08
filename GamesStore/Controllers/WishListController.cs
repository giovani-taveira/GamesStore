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
    public class WishListController : ControllerBase
    {
        private readonly IWishListService wishListService;

        public WishListController(IWishListService wishListService)
        {
            this.wishListService = wishListService;
        }

        [HttpGet]
        public IActionResult GetGamesFromWishList()
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            return Ok(wishListService.GetGames(_userId));
        }

        [HttpPost("{gameId}")]
        public IActionResult AddGameOnWishList(Guid gameId)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            return Ok(wishListService.AddGame(_userId, gameId));
        }

        [HttpDelete("{gameId}")]
        public IActionResult RemoveGame(Guid gameId)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            wishListService.RemoveGame(_userId, gameId);
            return NoContent();
        }
    }
}
