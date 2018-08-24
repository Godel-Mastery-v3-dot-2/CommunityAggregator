using System;

namespace GodelTech.CommunityAggregator.Api.Models
{
    public class ArticleView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
