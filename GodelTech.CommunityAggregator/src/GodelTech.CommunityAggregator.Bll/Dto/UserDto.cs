using GodelTech.CommunityAggregator.Dal.Agreements;

namespace GodelTech.CommunityAggregator.Bll.Dto
{
    public class UserDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
