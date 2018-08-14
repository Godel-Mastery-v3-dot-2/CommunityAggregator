﻿using GodelTech.CommunityAggregator.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GodelTech.CommunityAggregator.Dal.EntityFramework.Configurations
{
    internal class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(p => p.Title).HasMaxLength(256);
            builder.Property(p => p.Description).HasMaxLength(1024);
            builder.Property(p => p.ImageUrl).HasMaxLength(256);
        }
    }
}
