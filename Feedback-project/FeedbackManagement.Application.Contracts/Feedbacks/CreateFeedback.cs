using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application.Contracts.Feedbacks
{
    public class CreateFeedback
    {
        public long TargetId { get; set; }

        /// <summary>
        /// Task = 1, Project = 2
        /// </summary>
        public int RateTargetType { get; set; }

        public string Comment { get; set; }

        public long UserId { get; set; }
    }
}
