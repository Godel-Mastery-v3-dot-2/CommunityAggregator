using GodelTech.CommunityAggregator.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GodelTech.CommunityAggregator.Dal.EntityFramework.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(p => p.Login).HasMaxLength(128);
            builder.Property(p => p.PasswordHash).HasMaxLength(128);
            builder.Property(p => p.Role).HasColumnType("VARCHAR(50)");
        }
    }
}
