using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application.Contracts.Ratings
{
    public class RegisterRating
    {
        public long TargetId { get; set; }

        /// <summary>
        /// Task = 1, Project = 2
        /// </summary>
        public int RateTargetType { get; set; }

        /// <summary>
        /// Value between 1 and 5
        /// </summary>
        public int Value { get; set; }

        public long UserId { get; set; }
    }
}
