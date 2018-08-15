using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GodelTech.CommunityAggregator.Bll.Dto;
using GodelTech.CommunityAggregator.Bll.Interfaces;
using GodelTech.CommunityAggregator.Dal.Interfaces;
using GodelTech.CommunityAggregator.Dal.Models;

namespace GodelTech.CommunityAggregator.Bll.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IList<UserDto> GetUsers()
        {
            var users = unitOfWork.UserRepository.GetAll();
            var result = users.Select(item => mapper.Map<UserEntity, UserDto>(item)).ToList();

            return result;
        }

        public UserDto GetUser(int id)
        {
            var userEntity = unitOfWork.UserRepository.GetItem(id);
            var result = mapper.Map<UserEntity, UserDto>(userEntity);

            return result;
        }

        public void CreateUser(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userEntity = mapper.Map<UserDto, UserEntity>(user);
            unitOfWork.UserRepository.Create(userEntity);
        }

        public void UpdateUser(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userEntity = mapper.Map<UserDto, UserEntity>(user);
            unitOfWork.UserRepository.Update(userEntity);
        }

        public void RemoveUser(int id)
        {
            unitOfWork.UserRepository.Remove(id);
        }
    }
}
