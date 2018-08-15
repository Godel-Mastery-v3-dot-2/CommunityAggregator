using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<ArticleEntity> ArticleRepository { get; }
        void Commit();
    }
}
