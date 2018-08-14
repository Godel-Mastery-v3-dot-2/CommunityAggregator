using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Article> ArticleRepository { get; }
        void Commit();
    }
}
