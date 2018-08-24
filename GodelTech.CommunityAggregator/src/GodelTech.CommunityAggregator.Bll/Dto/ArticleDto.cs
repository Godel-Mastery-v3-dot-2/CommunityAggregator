using System;

namespace GodelTech.CommunityAggregator.Bll.Dto
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
