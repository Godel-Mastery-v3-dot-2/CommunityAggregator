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
            ArticleRepository = new Repository<ArticleEntity>(dbContext);
        }

        public IRepository<ArticleEntity> ArticleRepository { get; }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
