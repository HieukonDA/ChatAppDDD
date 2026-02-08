using Domain.IdentityContext.UsersAggregates;
using Domain.IdentityContext.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations.Identity
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("refresh_tokens");

            // Primary Key: RefreshTokenId (ValueObject)
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.Id)
                .HasColumnName("id")
                .HasConversion(
                    id => id.Id,
                    guid => RefreshTokenId.Create(guid)
                )
                .IsRequired();

            // Value (ValueObject)
            builder.Property(rt => rt.Value)
                .HasColumnName("value")
                .HasConversion(
                    value => value.Value,
                    str => RefreshTokenValue.Create(str)
                )
                .IsRequired();

            builder.Property(rt => rt.ExpiresAt)
                .HasColumnName("expires_at")
                .IsRequired();

            builder.Property(rt => rt.IsRevoked)
                .HasColumnName("is_revoked")
                .IsRequired();

            builder.Property(rt => rt.RevokedAt)
                .HasColumnName("revoked_at");

            builder.Property(rt => rt.CreatedByIp)
                .HasColumnName("created_by_ip");

            builder.Property(rt => rt.RevokedByIp)
                .HasColumnName("revoked_by_ip");

            // FK UserId (ValueObject)
            builder.Property(rt => rt.UserId)
                .HasColumnName("user_id")
                .HasConversion(
                    userId => userId.Id,
                    guid => UserId.Create(guid)
                )
                .IsRequired();

            builder.Ignore(rt => rt.DomainEvents);
        }
    }
}
