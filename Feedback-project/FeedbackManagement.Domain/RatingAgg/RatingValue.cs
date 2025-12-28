using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Domain.RatingAgg;

public sealed class RatingValue
{
    public int Value { get; }

    public RatingValue(int value)
    {
        RatingRules.CheckValueRange(value);
        Value = value;
    }
}

