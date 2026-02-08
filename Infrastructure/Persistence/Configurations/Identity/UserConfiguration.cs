using Domain.IdentityContext.UsersAggregates;
using Domain.IdentityContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            // Primary Key: Id (ValueObject)
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .HasColumnName("id")
                .HasConversion(
                    id => id.Id,
                    guid => UserId.Create(guid)
                )
                .IsRequired();

            // Email (ValueObject)
            builder.Property(u => u.Email)
                .HasColumnName("email")
                .HasMaxLength(255)
                .HasConversion(
                    email => email.Value,
                    value => Email.Create(value)
                )
                .IsRequired();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            // UserName (ValueObject)
            builder.Property(u => u.UserName)
                .HasColumnName("username")
                .HasMaxLength(20)
                .HasConversion(
                    userName => userName.Value,
                    value => UserName.Create(value)
                )
                .IsRequired();

            // PasswordHash (ValueObject)
            builder.Property(u => u.PasswordHash)
                .HasColumnName("password_hash")
                .HasConversion(
                    password => password.Value,
                    value => PasswordHash.Create(value)
                )
                .IsRequired();

            // PhoneNumber (ValueObject)
            builder.Property(u => u.PhoneNumber)
                .HasColumnName("phone_number")
                .HasMaxLength(12)
                .HasConversion(
                    phone => phone.Value,
                    value => PhoneNumber.Create(value)
                )
                .IsRequired(false);

            // AvatarUrl (ValueObject)
            builder.Property(u => u.AvatarUrl)
                .HasColumnName("avatar_url")
                .HasMaxLength(500)
                .HasConversion(
                    avatar => avatar.Value,
                    value => AvatarUrl.Create(value)
                )
                .IsRequired(false);

            // Relationship with RefreshTokens
            builder.HasMany(u => u.RefreshTokens)
                .WithOne()
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(u => u.DomainEvents);
        }
    }
}
