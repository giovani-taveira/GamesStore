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
        Review GetReview(Guid gameId);
        bool PostReview(Guid gameId, Guid userId, AddReviewInputModel model);
        bool PutReview(Guid id, UpdateReviewInputModel model);
        bool DeleteReview(Guid id);
    }
}
