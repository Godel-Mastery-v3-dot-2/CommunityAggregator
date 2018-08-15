using System.Collections.Generic;

namespace GodelTech.CommunityAggregator.Dal.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IList<T> GetAll();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Remove(int id);
    }
}
