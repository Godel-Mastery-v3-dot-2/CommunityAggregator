using System;
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
            NewsRepository = new Repository<News>(dbContext);
        }

        public IRepository<News> NewsRepository { get; set; }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        private bool disposed;

        public virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                dbContext.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
