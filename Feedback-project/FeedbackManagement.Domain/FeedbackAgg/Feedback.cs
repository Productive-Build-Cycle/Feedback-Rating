using _0_FrameWork.Domain;
using FeedbackManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Domain.FeedbackAgg;

public class Feedback : Entitybase
{
    public long TargetId { get; private set; }
    public RateTargetType TargetType { get; private set; }
    public long UserId { get; private set; }
    public string Comment { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Feedback() { }

    public Feedback(long targetId, RateTargetType targetType, long userId, string comment)
    {
        FeedbackRules.CheckComment(comment);

        TargetId = targetId;
        TargetType = targetType;
        UserId = userId;
        Comment = comment;
        CreatedAt = DateTime.UtcNow;
    }
}
