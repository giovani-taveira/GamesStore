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
        private readonly IUsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public ReviewController(IReviewRepository repository,IGameRepository gameRepository,IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetReview(int id)
        {
            var reviews = repository.GetReviews(id);
            if (reviews == null)
                return NotFound();

            return Ok(reviews);
        }

        [HttpPost]
        public IActionResult PostReview(int id, int userId, AddReviewInputModel model)
        {
            var user = usuarioRepository.GetUserById(userId);
            var game = gameRepository.GetById(id);
            var review = mapper.Map<Review>(model);

            //var review2 = new Review(userId, id, model.tag, model.estrelas, model.titulo, model.descricao);
            
            review.GameId = game.GameId;
            review.UsuarioId = userId;
            review.Descrição = model.descricao;
            review.TagUsuario = user.NickName;

            game.Reviews.Add(review);
            repository.AddReview(review);
            

            return Ok(review);

        }

        [HttpPut]
        public IActionResult PutReview(int id, UpdateReviewInputModel model)
        {
            var review = repository.GetReviews(id);

            review.UpdateReview(model.titulo, model.descricao);

            repository.UpdateReview(review);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteReview(int id)
        {
            var review = repository.GetReviews(id);

            repository.DeleteReview(review);

            return NoContent();

        }

    }
}
