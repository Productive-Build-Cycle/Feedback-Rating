using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Application.Contracts.Ratings
{
    public interface IRatingApplication
    {
        OperationResult Register(RegisterRating command);              // ثبت یک Rating جدید
        List<RatingViewModel> GetByTarget(long targetId, int rateTargetType); // گرفتن Rating‌ها برای یک Target
        AverageScoreViewModel GetAverage(long targetId, int rateTargetType);  // محاسبه میانگین امتیاز
    }
}
