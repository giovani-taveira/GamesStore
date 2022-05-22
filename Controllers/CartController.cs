using AutoMapper;
using GamesStore.Application.Interface;
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
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        [HttpGet]
        public IActionResult GetGamesFromCart(Guid userId)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            return Ok(cartService.GetGames(userId));
        }

        [HttpPost("{gameId}")]
        public IActionResult AddGameOnCart(Guid gameId)
        {
           
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            return Ok(cartService.AddGame(_userId, gameId));
        }

        [HttpDelete("{gameId}")]
        public IActionResult RemoveGame(Guid gameId)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            cartService.RemoveGame(_userId, gameId);

            return NoContent();
        }
    }
}
