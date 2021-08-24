using Lord.Gym.Domain.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lord.Gym.Infrastructure.Configurations.Auth
{
    public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.HasKey(a => a.JwtId);
            builder.HasOne(x => x.User)
                .WithMany(x => x.RefreshTokens)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
        }
    }
}