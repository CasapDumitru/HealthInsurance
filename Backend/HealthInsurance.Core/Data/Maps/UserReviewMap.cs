using HealthInsurance.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthInsurance.Core.Data.Maps
{
    public static class UserReviewMap
    {
        public static void Map(EntityTypeBuilder<UserReview> builder)
        {
            // Table
            builder
                .ToTable("UserReviews");

            // Key
            builder
                .HasKey(u => new { u.AuthorId, u.RecipientId });

            // Properties
            builder
                .Property(review => review.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder
                .Property(review => review.Mark)
                .IsRequired();

            // One-To-Many Relationship between User(Author) and CreatedUserReviews
            builder
                .HasOne(review => review.Author)
                .WithMany(user => user.CreatedUserReviews)
                .HasForeignKey(review => review.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            // One-To-Many Relationship between User(Recipient) and RecievedReviews
            builder
                .HasOne(review => review.Recipient)
                .WithMany(user => user.RecievedReviews)
                .HasForeignKey(review => review.RecipientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
