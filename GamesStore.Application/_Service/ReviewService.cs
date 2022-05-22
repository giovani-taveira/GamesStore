using GamesStore.Application.Interface;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application._Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IUserRepository userRepository;

        public ReviewService(IReviewRepository repository, IGameRepository gameRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
        }

        public Review GetReview(Guid id)
        {
            var reviews = repository.GetReviews(id);
            if (reviews == null)
                throw new Exception("Nenhuma review encontrada!");

            return reviews;
        }

        public bool PostReview(Guid gameId, Guid userId, AddReviewInputModel model)
        {
            var user = userRepository.GetUserById(userId);
            var game = gameRepository.GetById(gameId);
            var review = new Review(userId, game.GameId, user.GamerTag, model.stars, model.title, model.description);

            game.Reviews.Add(review);
            repository.AddReview(review);

            return true;
        }

        public bool PutReview(Guid id, UpdateReviewInputModel model)
        {
            var review = repository.GetReviews(id);
            review.UpdateReview(model.title, model.description);
            repository.UpdateReview(review);

            return true;
        }

        public bool DeleteReview(Guid id)
        {
            if (repository.GetReviews(id) == null)
                throw new Exception("Nenhuma review encontrada!");

            var review = repository.GetReviews(id);
            repository.DeleteReview(review);

            return true;
        }

    }
}
