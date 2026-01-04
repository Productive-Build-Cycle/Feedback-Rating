using _0_Framework.Application;
using _0_FrameWork.Domain;
using FeedbackManagement.Application.Contracts.Feedbacks;
using FeedbackManagement.Domain.Enums;
using FeedbackManagement.Domain.FeedbackAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application
{
    public class FeedbackApplication
    {
        private readonly IFeedbackRepository _feedbackRepository;

        public FeedbackApplication(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }


        public OperationResult Create(CreateFeedback command)
        {
            var result = new OperationResult();
            var targetType = (RateTargetType)command.RateTargetType;

            if (_feedbackRepository.ExistsForUser(command.TargetId, targetType, command.UserId))
                return result.Failed("User already submitted feedback.");

            try
            {
                var feedback = new Feedback(command.TargetId, targetType, command.UserId, command.Comment);
                _feedbackRepository.Create(feedback);
                _feedbackRepository.SaveChanges();
                return result.Succedded();
            }
            catch (DomainException ex)
            {
                return result.Failed(ex.Message);
            }
        }

        public FeedbackViewModel Get(long id)
        {
            var f = _feedbackRepository.Get(id);
            if (f == null) return null;

            return new FeedbackViewModel(f.Id, f.TargetId, (int)f.TargetType, f.UserId, f.Comment, f.CreatedAt);
        }

        public List<FeedbackViewModel> GetByTarget(long targetId, int rateTargetType)
        {
            var list = _feedbackRepository.GetByTarget(targetId, (RateTargetType)rateTargetType);
            return list.Select(f => new FeedbackViewModel(f.Id, f.TargetId, (int)f.TargetType, f.UserId, f.Comment, f.CreatedAt)).ToList();
        }

        public List<FeedbackViewModel> GetAll()
        {
            var all = _feedbackRepository.Get();
            return all.Select(f => new FeedbackViewModel(f.Id, f.TargetId, (int)f.TargetType, f.UserId, f.Comment, f.CreatedAt)).ToList();
        }



    }
}
