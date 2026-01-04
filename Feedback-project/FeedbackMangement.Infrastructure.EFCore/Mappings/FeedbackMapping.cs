using FeedbackManagement.Domain.FeedbackAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackMangement.Infrastructure.EFCore.Mappings
{
    public class FeedbackMapping : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.ToTable("Feedbacks");

            // کلید اصلی
            builder.HasKey(f => f.Id);

            // ستون‌ها
            builder.Property(f => f.TargetId)
                .IsRequired();

            builder.Property(f => f.TargetType)
                .IsRequired();

            builder.Property(f => f.UserId)
                .IsRequired();

            builder.Property(f => f.Comment)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(f => f.CreatedAt)
                .IsRequired();

            // اگر نیاز باشه می‌تونی ایندکس هم تعریف کنی
            builder.HasIndex(f => new { f.TargetId, f.TargetType });
            builder.HasIndex(f => f.UserId);
        }
    }
}
