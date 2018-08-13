using GodelTech.CommunityAggregator.Dal.EntityFramework;
using GodelTech.CommunityAggregator.Dal.Interfaces;
using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Dal.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext dbContext;

        public UnitOfWork(EntityContext dbContext)
        {
            this.dbContext = dbContext;
            NewsRepository = new Repository<Article>(dbContext);
        }

        public IRepository<Article> NewsRepository { get; }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
