using System.Collections.Generic;
using System.Linq;
using GodelTech.CommunityAggregator.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GodelTech.CommunityAggregator.Dal.Repositories
{
    public class Repository<T> : IRepository<T>
        where T: class
    {
        private readonly DbSet<T> dbSet;

        public Repository(DbContext dbContext)
        {
            dbSet = dbContext.Set<T>();
        }

        public IList<T> GetAll()
        {
            return dbSet.ToList();
        }

        public T GetItem(int id)
        {
            return dbSet.Find(id);
        }

        public void Create(T item)
        {
            dbSet.Add(item);
        }

        public void Update(T item)
        {
            dbSet.Update(item);
        }

        public void Remove(int id)
        {
            var item = dbSet.Find(id);
            if (item != null)
            {
                dbSet.Remove(item);
            }
        }
    }
}
