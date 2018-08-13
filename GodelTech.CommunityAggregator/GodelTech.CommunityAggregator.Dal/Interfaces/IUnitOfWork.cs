using System;
using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Dal.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<News> NewsRepository { get; set; }
        void Commit();
    }
}
