using System.Collections.Generic;
using GodelTech.CommunityAggregator.Bll.Dto;

namespace GodelTech.CommunityAggregator.Bll.Interfaces
{
    public interface IAccountService
    {
        IList<UserDto> GetUsers();
        UserDto GetUser(int id);
        void CreateUser(UserDto user);
        void UpdateUser(UserDto user);
        void RemoveUser(int id);
    }
}
