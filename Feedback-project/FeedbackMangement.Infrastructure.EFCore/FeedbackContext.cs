using FeedbackManagement.Domain.FeedbackAgg;
using FeedbackMangement.Infrastructure.EFCore.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;

namespace FeedbackMangement.Infrastructure.EFCore
{
    public class FeedbackContext : DbContext
    {
     
        public DbSet<Feedback> Feedbacks { get; set; }
        public FeedbackContext(DbContextOptions<FeedbackContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(FeedbackMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
