using AppNet.Domain.Models;
using AppNet.Repository.Base;
using AppNet.Repository.Infrastructure;
using AppNet.Services.Service.Infastructure;
using AppNet.Services.Service.Managers;
using AppNet.Services.ViewModels;
using AutoMapper;
using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AppNet.Services.Service
{
    public class UserService : IUserService
    {
        IUserRepository repository;
        IBaseRepository<User> baseRepository;
        Mapper mapper;

        public UserService(IUserRepository _userRepository, IBaseRepository<User> _baseRepository)
        {
            repository = _userRepository;
            baseRepository = _baseRepository;
            var mapperConf = Configurations.MapperConfig.Configure();
            mapper = new Mapper(mapperConf);
        }
        public UserViewModel Create(UserViewModel model)
        {
            var userObject = mapper.Map<UserViewModel, User>(model);
            userObject.CreateOn = DateTime.Now;
            userObject.ModifyOn = DateTime.Now;
            userObject.LastLoginDate = DateTime.Now;
            userObject = repository.Create(userObject);
            model = mapper.Map<User, UserViewModel>(userObject);
            return model;
        }

        public bool Delete(UserViewModel model)
        {
            return baseRepository.Delete(model.Id);

        }

        public bool Delete(int id)
        {
            return baseRepository.Delete(id);
        }

        public UserViewModel Get(int id)
        {
            var userObject = baseRepository.Get(id);
            Condition.Requires(userObject).IsNotNull();
            return mapper.Map<User, UserViewModel>(userObject);
        }

        public List<UserViewModel> GetAll(Expression<Func<UserViewModel, bool>> predicate = null)
        {
            var userList = repository.GetAll().ToList();
            var userViewModelList = userList.Select(p => mapper.Map<User, UserViewModel>(p));
            if (predicate == null) return userViewModelList.ToList();
            return userViewModelList.AsQueryable().Where(predicate).ToList();
        }

        public bool Login(UserViewModel model)
        {
            var userObject = repository.Login(model.UserName, model.Password);
            if (userObject != null)
            {
                var userViewModel = mapper.Map<User, UserViewModel>(userObject);
                UserManager.ActiveUser = userViewModel;
                return true;
            }
            return false;
        }

        public bool Update(UserViewModel model)
        {
            var userObject = mapper.Map<UserViewModel, User>(model);
            Condition.Requires(userObject).IsNotNull();

            userObject.ModifyOn = DateTime.Now;
            userObject.CreateOn = DateTime.Now;
            userObject.LastLoginDate = DateTime.Now;

            return baseRepository.Update(userObject);
        }

        public bool Update(int id)
        {
            //baseRepository.Get(id);
            //return baseRepository.Update(id);
            throw new Exception();
        }
    }
}
