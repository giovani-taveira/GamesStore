using AutoMapper;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IUserRepository userRepository;

        public ReviewController(IReviewRepository repository,IGameRepository gameRepository,IUserRepository userRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            var reviews = repository.GetReviews(id);
            if (reviews == null)
                return NotFound();

            return Ok(reviews);
        }

        [HttpPost("{gameId}/{userId}")]
        public IActionResult PostReview(int gameId, int userId, AddReviewInputModel model)
        {
            var user = userRepository.GetUserById(userId);
            var game = gameRepository.GetById(gameId);
            var review = new Review(userId, game.GameId, user.GamerTag, model.stars, model.title, model.description);

            game.Reviews.Add(review);
            repository.AddReview(review);
            
            return Ok(review);
        }

        [HttpPut("{id}")]
        public IActionResult PutReview(int id, UpdateReviewInputModel model)
        {
            var review = repository.GetReviews(id);
            review.UpdateReview(model.title, model.description);
            repository.UpdateReview(review);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            if (repository.GetReviews(id) == null)
                return NotFound();

            var review = repository.GetReviews(id);
            repository.DeleteReview(review);

            return NoContent();
        }
    }
}
