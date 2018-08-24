using System;

namespace GodelTech.CommunityAggregator.Dal.Models
{
    public class ArticleEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
