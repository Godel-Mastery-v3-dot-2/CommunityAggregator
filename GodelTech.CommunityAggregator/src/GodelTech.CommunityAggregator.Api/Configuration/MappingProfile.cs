using AutoMapper;
using GodelTech.CommunityAggregator.Api.Models;
using GodelTech.CommunityAggregator.Bll.Dto;
using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Api.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ArticleDto to DomainModel and back
            CreateMap<ArticleDto, ArticleEntity>();
            CreateMap<ArticleEntity, ArticleDto>();

            CreateMap<ArticleDto, ArticleView>();
            CreateMap<ArticleView, ArticleDto>();

            CreateMap<UserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>();

            CreateMap<UserDto, LoginView>();
            CreateMap<LoginView, UserDto>();
        }
    }
}
