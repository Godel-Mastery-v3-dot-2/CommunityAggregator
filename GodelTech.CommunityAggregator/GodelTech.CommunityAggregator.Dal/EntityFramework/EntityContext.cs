using GodelTech.CommunityAggregator.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace GodelTech.CommunityAggregator.Dal.EntityFramework
{
    public sealed class EntityContext : DbContext
    {
        public DbSet<News> Newses { get; set; }

        public EntityContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=[CommunityAggregator];Trusted_Connection=True;");
        }
    }
}
