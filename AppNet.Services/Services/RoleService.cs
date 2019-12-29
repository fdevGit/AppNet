﻿using AppNet.Domain.Models;
using AppNet.Repository.Repository;
using AppNet.Services.Services.Infastructure;
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
    public class RoleService : IRoleService
    {
        BaseRepository<Role> repos = new BaseRepository<Role>();
        Mapper mapper;
        public RoleService()
        {
            var mapperConfig = Configurations.MapperConfig.Configure();
            mapper = new Mapper(mapperConfig);
        }
        public RoleViewModel Create(RoleViewModel model)
        {
            try
            {
                var roleObject = repos.Create(mapper.Map<RoleViewModel, Role>(model));
                return mapper.Map<Role, RoleViewModel>(roleObject);
            }
            catch (Exception ex)
            {
                model.AddError(ex.Message);
                return model;
            }
        }

        public bool Delete(RoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RoleViewModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoleViewModel> GetAll(Expression<Func<RoleViewModel, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(RoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
