using System.Collections.Generic;
using GodelTech.CommunityAggregator.Bll.Dto;

namespace GodelTech.CommunityAggregator.Bll.Interfaces
{
    public interface IArticleService
    {
        IList<ArticleDto> GetAllArticles();
        ArticleDto GetArticle(int id);
        void CreateArticle(ArticleDto article);
        void UpdateArticle(int id, ArticleDto article);
        void RemoveArticle(int id);
    }
}
