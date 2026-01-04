using _0_FrameWork.Domain;
using FeedbackManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace FeedbackManagement.Domain.FeedbackAgg;

public interface IFeedbackRepository : IRepository<long, Feedback>
{
    List<Feedback> GetByTarget(long targetId, RateTargetType targetType);
    bool ExistsForUser(long targetId, RateTargetType targetType, long userId);
}
