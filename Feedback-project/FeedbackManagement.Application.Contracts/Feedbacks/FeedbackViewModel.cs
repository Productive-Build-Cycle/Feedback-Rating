using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application.Contracts.Feedbacks
{
    public record FeedbackViewModel(
     long Id,
     long TargetId,
     int RateTargetType,
     long UserId,
     string Comment,
     DateTime CreatedAt
 );
}
