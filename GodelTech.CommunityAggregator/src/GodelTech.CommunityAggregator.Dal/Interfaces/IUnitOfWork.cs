using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Dal.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<ArticleEntity> ArticleRepository { get; }
        IRepository<UserEntity> UserRepository { get; }
        void Commit();
    }
}
