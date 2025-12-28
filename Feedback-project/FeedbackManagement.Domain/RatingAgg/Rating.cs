using _0_FrameWork.Domain;
using FeedbackManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Domain.RatingAgg;

public class Rating : Entitybase
{
    public long TargetId { get; private set; }
    public RateTargetType TargetType { get; private set; }
    public long UserId { get; private set; }
    public RatingValue Value { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Rating() { } 

    public Rating(long targetId, RateTargetType targetType, long userId, int value)
    {
        TargetId = targetId;
        TargetType = targetType;
        UserId = userId;
        Value = new RatingValue(value);
        CreatedAt = DateTime.UtcNow;
    }
}
