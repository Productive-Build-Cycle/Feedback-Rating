using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application.Contracts.Ratings
{
    public record RatingViewModel(
     long Id,
     long TargetId,
     int RateTargetType,
     int Value,
     long UserId,
     DateTime CreatedAt
 );
}
