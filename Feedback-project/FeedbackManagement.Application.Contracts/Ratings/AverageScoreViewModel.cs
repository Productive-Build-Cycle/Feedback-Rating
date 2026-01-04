using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application.Contracts.Ratings
{
    public record AverageScoreViewModel(
     long TargetId,
     int RateTargetType,
     double AverageScore,
     int TotalVotes
 );
}
