using GamesStore.Entities;
using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application.Interface
{
    public interface IReviewService
    {
        Review GetReview(int gameId);
        bool PostReview(int gameId, int userId, AddReviewInputModel model);
        bool PutReview(int id, UpdateReviewInputModel model);
        bool DeleteReview(int id);
    }
}
