using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface IReviewRepository
    {
        Review GetReviews(int id);
        void AddReview(Review review);
        void UpdateReview(Review review);
        void DeleteReview(Review review);
    }
}
