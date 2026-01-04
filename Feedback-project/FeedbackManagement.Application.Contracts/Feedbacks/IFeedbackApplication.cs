using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application.Contracts.Feedbacks
{
    public interface IFeedbackApplication
    {
        OperationResult Create(CreateFeedback command);
        FeedbackViewModel Get(long id);
        List<FeedbackViewModel> GetByTarget(long targetId, int rateTargetType);
        List<FeedbackViewModel> GetAll();

    }
}
