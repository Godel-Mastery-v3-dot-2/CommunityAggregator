using System.Security.Claims;
using GodelTech.CommunityAggregator.Bll.Dto;

namespace GodelTech.CommunityAggregator.Bll.Interfaces
{
    public interface IAccountService
    {
        ClaimsIdentity GetIndentity(string login, string password);
        void CreateUser(UserDto user);
    }
}
