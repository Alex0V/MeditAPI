using Medit.DAL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Medit.DAL.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Password)
                .IsRequired();

            builder.Property(e => e.Token);

            builder.Property(e => e.Role)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(e => e.RefreshToken);

            builder.Property(e => e.RefreshTokenExpiryTime);

            builder.Property(e => e.ResetPasswordToken);

            builder.Property(e => e.ResetPasswordExpiry);
        }
    }
}
