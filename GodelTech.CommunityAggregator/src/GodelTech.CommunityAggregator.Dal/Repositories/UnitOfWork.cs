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
            UserRepository = new Repository<UserEntity>(dbContext);
        }

        public IRepository<ArticleEntity> ArticleRepository { get; }
        public IRepository<UserEntity> UserRepository { get; }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
