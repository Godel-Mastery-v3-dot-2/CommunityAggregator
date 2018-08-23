using System.ComponentModel.DataAnnotations;

namespace GodelTech.CommunityAggregator.Api.Models
{
    public class LoginView
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
