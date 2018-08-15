using GodelTech.CommunityAggregator.Dal.EntityFramework.Configurations;
using GodelTech.CommunityAggregator.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace GodelTech.CommunityAggregator.Dal.EntityFramework
{
    public sealed class EntityContext : DbContext
    {
        public DbSet<ArticleEntity> Articles { get; set; }

        public EntityContext(DbContextOptions<EntityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        }
    }
}
