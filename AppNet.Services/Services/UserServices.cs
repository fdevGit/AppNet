using AppNet.Domain.Models;
using AppNet.Repository.Repository;
using AppNet.Services.Services.Infastructure;
using AppNet.Services.Services.Managers;
using AppNet.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.Services
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
            throw new NotImplementedException();
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

        public List<UserViewModel> GetAll(Expression<Func<UserViewModel, bool>> expression = null)
        {
            throw new NotImplementedException();
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
