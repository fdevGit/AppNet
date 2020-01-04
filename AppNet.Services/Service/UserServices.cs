using AppNet.Domain.Models;
using AppNet.Repository.Repository;
using AppNet.Services.Service.Infastructure;
using AppNet.Services.Service.Managers;
using AppNet.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.Service
{
    public class UserServices : IUserService
    {
        UserRepository repository;
        Mapper mapper;

        public UserServices()
        {
            repository = new UserRepository();
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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserViewModel Get(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
