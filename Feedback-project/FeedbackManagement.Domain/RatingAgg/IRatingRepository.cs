using _0_FrameWork.Domain;
using FeedbackManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Domain.RatingAgg;

public interface IRatingRepository : IRepository<long, Rating>
{
    List<Rating> GetByTarget(long targetId, RateTargetType targetType);
    bool ExistsForUser(long targetId, RateTargetType targetType, long userId);
}

