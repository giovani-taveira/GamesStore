using GamesStore.Entities;

namespace GamesStore.Data.Repositories.Game
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly GameStoreContext context;

        public ReviewRepository(GameStoreContext context)
        {
            this.context = context;
        }

        public Review GetReviews(Guid id)
        {
            return context.Reviews.SingleOrDefault(c => c.Id == id);
        }

        public void AddReview(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
        }

        public void DeleteReview(Review review)
        {
            context.Reviews.Remove(review);
            context.SaveChanges();
        }

        public void UpdateReview(Review review)
        {
            context.Reviews.Update(review);
            context.SaveChanges();
        }
    }
}
