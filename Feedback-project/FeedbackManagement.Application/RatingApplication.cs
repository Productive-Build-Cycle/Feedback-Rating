using _0_Framework.Application;
using _0_FrameWork.Domain;
using FeedbackManagement.Application.Contracts.Ratings;
using FeedbackManagement.Domain.Enums;
using FeedbackManagement.Domain.RatingAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application
{
    public class RatingApplication : IRatingApplication
    {
        private readonly IRatingRepository _repository;

        public RatingApplication(IRatingRepository repository)
        {
            _repository = repository;
        }

        public OperationResult Register(RegisterRating command)
        {
            var result = new OperationResult();
            var targetType = (RateTargetType)command.RateTargetType;

            if (_repository.ExistsForUser(command.TargetId, targetType, command.UserId))
                return result.Failed(ApplicationMessages.Limit);

            try
            {
                var rating = new Rating(command.TargetId, targetType, command.UserId, command.Value);
                _repository.Create(rating);
                _repository.SaveChanges();
                return result.Succedded();
            }
            catch (DomainException ex)
            {
                return result.Failed(ex.Message);
            }
        }

        public List<RatingViewModel> GetByTarget(long targetId, int rateTargetType)
        {
            var list = _repository.GetByTarget(targetId, (RateTargetType)rateTargetType);
            return list.Select(r => new RatingViewModel(r.Id, r.TargetId, (int)r.TargetType, r.Value.Value, r.UserId, r.CreatedAt)).ToList();
        }

        public AverageScoreViewModel GetAverage(long targetId, int rateTargetType)
        {
            if (!Enum.IsDefined(typeof(RateTargetType), rateTargetType))
                throw new ArgumentException("RateTargetType نامعتبر");

            var targetEnum = (RateTargetType)rateTargetType;

            var list = _repository.GetByTarget(targetId, targetEnum);

            if (!list.Any())
                return new AverageScoreViewModel(targetId, rateTargetType, 0, 0);

            var avg = list.Average(r => r.Value.Value);
            return new AverageScoreViewModel(targetId, rateTargetType, avg, list.Count);
        }
    }
}
