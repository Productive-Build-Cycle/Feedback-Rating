using FeedbackManagement.Domain.RatingAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FeedbackMangement.Infrastructure.EFCore.Mappings
{
    public class RatingMapping : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            // جدول و کلید اصلی
            builder.ToTable("Ratings");
            builder.HasKey(r => r.Id);

            // ستون‌ها
            builder.Property(r => r.TargetId)
                .IsRequired();

            builder.Property(r => r.TargetType)
                .IsRequired();

            builder.Property(r => r.UserId)
                .IsRequired();

            // Value را به عنوان ستون عددی ذخیره می‌کنیم
            builder.Property(r => r.Value)
                   .HasConversion(
                        v => v.Value,           // تبدیل RatingValue -> int برای ذخیره
                        v => new RatingValue(v) // تبدیل int -> RatingValue برای خواندن
                    )
                   .IsRequired();

            builder.Property(r => r.CreatedAt)
                .IsRequired();

            // Index برای جستجوهای سریع بر اساس Target و User
            builder.HasIndex(r => new { r.TargetId, r.TargetType });
            builder.HasIndex(r => new { r.TargetId, r.TargetType, r.UserId }).IsUnique();
        }


    }
}
