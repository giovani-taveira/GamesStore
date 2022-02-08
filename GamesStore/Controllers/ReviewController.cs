using AutoMapper;
using GamesStore.Application.Interface;
using GamesStore.Authentication.Services;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [HttpGet("{id}")]
        public IActionResult GetReview(Guid id)
        {
            return Ok(reviewService.GetReview(id));
        }

        [HttpPost("{gameId}")]
        public IActionResult PostReview(Guid gameId, AddReviewInputModel model)
        {
            Guid _userId = Guid.Parse(TokenServices.GetValueFromClaim(HttpContext.User.Identity, ClaimTypes.NameIdentifier));
            
            return Ok(reviewService.PostReview(gameId, _userId, model));
        }

        [HttpPut("{id}")]
        public IActionResult PutReview(Guid id, UpdateReviewInputModel model)
        {
            reviewService.PutReview(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(Guid id)
        {
            reviewService.DeleteReview(id);
            return NoContent();
        }
    }
}
