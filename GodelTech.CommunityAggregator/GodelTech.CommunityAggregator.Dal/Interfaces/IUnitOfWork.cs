using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Article> NewsRepository { get; }
        void Commit();
    }
}
