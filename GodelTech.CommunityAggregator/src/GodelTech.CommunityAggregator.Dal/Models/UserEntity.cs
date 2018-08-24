using GodelTech.CommunityAggregator.Dal.Agreements;

namespace GodelTech.CommunityAggregator.Dal.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public int PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
