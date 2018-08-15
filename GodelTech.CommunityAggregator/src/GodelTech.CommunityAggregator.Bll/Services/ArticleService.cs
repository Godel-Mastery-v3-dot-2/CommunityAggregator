using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GodelTech.CommunityAggregator.Bll.Dto;
using GodelTech.CommunityAggregator.Bll.Interfaces;
using GodelTech.CommunityAggregator.Dal.Interfaces;
using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Bll.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            this.mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public IList<ArticleDto> GetAllArticles()
        {
            var articles = unitOfWork.ArticleRepository.GetAll();
            var articlesDto = articles
                .Select(article => mapper.Map<ArticleEntity, ArticleDto>(article)).ToList();

            return articlesDto;
        }

        public ArticleDto GetArticle(int id)
        {
            var article = unitOfWork.ArticleRepository.GetItem(id);
            if (article == null)
            {
                throw new KeyNotFoundException($"Article {id} not found!");
            }

            return mapper.Map<ArticleEntity, ArticleDto>(article);
        }

        public void CreateArticle(ArticleDto article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            var newArticle = mapper.Map<ArticleDto, ArticleEntity>(article);
            unitOfWork.ArticleRepository.Create(newArticle);
            unitOfWork.Commit();
        }

        public void UpdateArticle(int id, ArticleDto article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            var updatedArticle = mapper.Map<ArticleDto, ArticleEntity>(article);
            updatedArticle.Id = id;
            unitOfWork.ArticleRepository.Update(updatedArticle);
            unitOfWork.Commit();
        }

        public void RemoveArticle(int id)
        {
            unitOfWork.ArticleRepository.Remove(id);
            unitOfWork.Commit();
        }
    }
}
