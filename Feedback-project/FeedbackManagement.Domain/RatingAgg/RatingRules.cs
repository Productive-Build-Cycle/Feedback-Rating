using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Domain.RatingAgg;

public static class RatingRules
{
    public static void CheckValueRange(int value) // to validate Points
    {
        if (value < 1 || value > 5)
            throw new DomainException("Rating value must be between 1 and 5.");
    }
}
