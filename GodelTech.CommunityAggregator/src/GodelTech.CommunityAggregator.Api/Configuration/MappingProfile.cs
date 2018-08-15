using AutoMapper;
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
        }
    }
}
