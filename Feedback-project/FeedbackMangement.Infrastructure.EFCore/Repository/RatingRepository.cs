using _0_FrameWork.Infrastructure;
using FeedbackManagement.Domain.Enums;
using FeedbackManagement.Domain.RatingAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackMangement.Infrastructure.EFCore.Repository
{
    public class RatingRepository : RepositoryBase<long, Rating>, IRatingRepository
    {
        private readonly FeedbackContext _context;

        public RatingRepository(FeedbackContext context) : base(context)
        {
            _context = context;
        }

        public List<Rating> GetByTarget(long targetId, RateTargetType targetType)
        {
            return _context.Set<Rating>()
                .Where(r => r.TargetId == targetId && r.TargetType == targetType)
                .OrderByDescending(r => r.CreatedAt)
                .ToList();
        }

        public bool ExistsForUser(long targetId, RateTargetType targetType, long userId)
        {
            return _context.Set<Rating>()
                .Any(r => r.TargetId == targetId && r.TargetType == targetType && r.UserId == userId);
        }
    }
}
