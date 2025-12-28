using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Domain.FeedbackAgg;

public static class FeedbackRules
{
    public static void CheckComment(string comment)
    {
        if (string.IsNullOrWhiteSpace(comment))
            throw new DomainException("Feedback comment cannot be empty.");

        if (comment.Length > 1000)
            throw new DomainException("Feedback comment is too long.");
        if (comment.Length < 15)
            throw new DomainException("Its too short");
    }
}
