namespace GodelTech.CommunityAggregator.Dal.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }
        public string Role { get; set; }
    }
}
