// ReSharper disable ObjectCreationAsStatement
using System;
using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using GodelTech.CommunityAggregator.Bll.Dto;
using GodelTech.CommunityAggregator.Bll.Services;
using GodelTech.CommunityAggregator.Dal.Interfaces;
using GodelTech.CommunityAggregator.Dal.Models;
using Moq;
using Xunit;

namespace GodelTech.CommunityAggregator.Tests.BusinessLogicTests
{
    public class ArticleServiceTests
    {
        private readonly ArticleService articleService;
        private readonly Mock<IMapper> mapper;
        private readonly Mock<IUnitOfWork> unitOfWork;
        private readonly Mock<IRepository<ArticleEntity>> articleRepository;

        public ArticleServiceTests()
        {
            var articles = new List<ArticleEntity>
            {
                new ArticleEntity {Id = 1, Title = "Article1", Description = "Description1", ImageUrl = "Url", PublishDate = DateTime.Now.Date},
                new ArticleEntity {Id = 2, Title = "Article2", Description = "Description1", ImageUrl = "Url", PublishDate = DateTime.Now.Date},
                new ArticleEntity {Id = 3, Title = "Article3", Description = "Description1", ImageUrl = "Url", PublishDate = DateTime.Now.Date},
                new ArticleEntity {Id = 4, Title = "Article4", Description = "Description1", ImageUrl = "Url", PublishDate = DateTime.Now.Date},
                new ArticleEntity {Id = 5, Title = "Article5", Description = "Description1", ImageUrl = "Url", PublishDate = DateTime.Now.Date}
            };

            mapper = new Mock<IMapper>();
            mapper.Setup(p => p.Map<ArticleDto, ArticleEntity>(It.IsAny<ArticleDto>())).Returns(new ArticleEntity());
            mapper.Setup(p => p.Map<ArticleEntity, ArticleDto>(It.IsAny<ArticleEntity>())).Returns(new ArticleDto());

            articleRepository = new Mock<IRepository<ArticleEntity>>();
            articleRepository.Setup(p => p.GetAll()).Returns(articles);
            articleRepository.Setup(p => p.GetItem(0)).Returns(articles[0]);
            articleRepository.Setup(p => p.GetItem(1)).Returns((ArticleEntity)null);
            articleRepository.Setup(p => p.Remove(It.IsAny<int>())).Verifiable();

            unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(p => p.ArticleRepository).Returns(articleRepository.Object);

            articleService = new ArticleService(unitOfWork.Object, mapper.Object);
        }

        [Fact]
        public void ArticleService_When_Object_Created_Should_Return_NotNull()
        {
            // Assert
            articleService.Should().NotBeNull();
        }

        [Fact]
        public void ArticleService_When_UnitOfWork_IsNull_Should_Throw_ArgumentNullException()
        {
            // Act
            Action action = () => { new ArticleService(null, mapper.Object); };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void ArticleService_When_Mapper_IsNull_Should_Throw_ArgumentNullException()
        {
            // Act
            Action action = () =>
            {
                new ArticleService(unitOfWork.Object, null);
            };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void GetAllArticles_When_Return_Test_Collection_Should_Return_Five_Elements()
        {
            // Act
            var result = articleService.GetAllArticles();

            // Assert
            result.Should().HaveCount(5);
        }

        [Fact]
        public void GetArticle_When_Id_Not_Exist_Should_Throw_Exception()
        {
            // Act
            Action action = () => { articleService.GetArticle(1); };

            // Assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void GetArticle_When_Id_Exist_Should_Return_Model()
        {
            // Act
            var result = articleService.GetArticle(0);

            // Assert
            result.Should().BeEquivalentTo(new ArticleDto());
        }

        [Fact]
        public void CreateArticle_When_ArticleDto_isNull_Should_Throw_ArgumentNullException()
        {
            // Act
            Action action = () => { articleService.CreateArticle(null); };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void CreateArticle_When_ArticleDto_NotNull_Should_Verify_Repository()
        {
            // Act
            articleService.CreateArticle(new ArticleDto());

            // Assert
            articleRepository.Verify(p => p.Create(It.IsAny<ArticleEntity>()), Times.Once);
        }

        [Fact]
        public void UpdateArticle_When_ArticleDto_IsNull_Should_Throw_ArgumentNullException()
        {
            // Act
            Action action = () => { articleService.UpdateArticle(0, null); };

            // Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void UpdateArticle_When_ArticleDto_NotNull_Should_Verify_Repository()
        {
            // Act
            articleService.UpdateArticle(0, new ArticleDto());

            // Assert
            articleRepository.Verify(p => p.Update(It.IsAny<ArticleEntity>()), Times.Once);
        }

        [Fact]
        public void RemoveArticle_When_Used_Repository_Method_Should_Verify_Repository()
        {
            // Act
            articleService.RemoveArticle(0);

            // Assert
            articleRepository.Verify(p => p.Remove(It.IsAny<int>()), Times.Once);
        }
    }
}
