using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GodelTech.CommunityAggregator.Dal.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Create(T item);
        void Update(T item);
        void Remove(int id);
    }
}
