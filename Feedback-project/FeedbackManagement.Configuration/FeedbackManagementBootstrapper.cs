using FeedbackManagement.Application;
using FeedbackManagement.Application.Contracts.Feedbacks;
using FeedbackManagement.Application.Contracts.Ratings;
using FeedbackManagement.Domain.FeedbackAgg;
using FeedbackManagement.Domain.RatingAgg;
using FeedbackMangement.Infrastructure.EFCore;
using FeedbackMangement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackManagement.Configuration
{
    public class FeedbackManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IRatingApplication, RatingApplication>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IFeedbackApplication, FeedbackApplication>();

            services.AddDbContext<FeedbackContext>(x => x.UseSqlServer(connectionString));

        }
    }
}
