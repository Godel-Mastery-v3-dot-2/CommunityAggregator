using System;
using System.Collections.Generic;
using System.Linq;
using GodelTech.CommunityAggregator.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GodelTech.CommunityAggregator.Dal.Repositories
{
    public class Repository<T> : IRepository<T>
        where T: class
    {
        private readonly DbSet<T> entity;
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            entity = dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return entity;
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return entity.Where(predicate);
        }

        public void Create(T item)
        {
            entity.Add(item);
        }

        public void Update(T item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
        }

        public void Remove(int id)
        {
            var item = entity.Find(id);
            if (item != null)
            {
                entity.Remove(item);
            }
        }
    }
}
