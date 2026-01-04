using _0_FrameWork.Infrastructure;
using FeedbackManagement.Domain.Enums;
using FeedbackManagement.Domain.FeedbackAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackMangement.Infrastructure.EFCore.Repository
{
    public class FeedbackRepository : RepositoryBase<long, Feedback>, IFeedbackRepository
    {
        private readonly FeedbackContext _feedbackcontext;

        public FeedbackRepository(FeedbackContext feedbackcontext) : base(feedbackcontext) 
        {
            _feedbackcontext = feedbackcontext;
        }

        public List<Feedback> GetByTarget(long targetId, RateTargetType targetType)
        {
            return _feedbackcontext.Feedbacks
                .Where(f => f.TargetId == targetId && f.TargetType == targetType)
                .OrderByDescending(f => f.CreatedAt)
                .ToList();
        }

        public bool ExistsForUser(long targetId, RateTargetType targetType, long userId)
        {
            return _feedbackcontext.Feedbacks
                .Any(f => f.TargetId == targetId && f.TargetType == targetType && f.UserId == userId);
        }
    }
}
