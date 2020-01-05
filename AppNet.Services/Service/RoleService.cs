using AppNet.Domain.Models;
using AppNet.Repository.Base;
using AppNet.Repository.Repository;
using AppNet.Services.Service.Infastructure;
using AppNet.Services.ViewModels;
using AutoMapper;
using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.Service
{
    public class RoleService : IRoleService
    {
        IBaseRepository<Role> repos;
        Mapper mapper;
        public RoleService(IBaseRepository<Role> _baseRepository)
        {
            repos = _baseRepository;
            var mapperConfig = Configurations.MapperConfig.Configure();
            mapper = new Mapper(mapperConfig);
        }
        public RoleViewModel Create(RoleViewModel model)
        {
            try
            {
                model.CreatedOn = DateTime.Now;
                model.ModifiedOn = DateTime.Now;

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
            return repos.Delete(model.Id);
        }

        public bool Delete(int id)
        {
            return repos.Delete(id);
        }

        public RoleViewModel Get(int id)
        {
            var roleObject = repos.Get(id);
            Condition.Requires(roleObject).IsNotNull();
            var roleViewModel = mapper.Map<Role, RoleViewModel>(roleObject);
            Condition.Requires(roleViewModel).IsNotNull();
            return roleViewModel;
        }

        public List<RoleViewModel> GetAll(Expression<Func<RoleViewModel, bool>> predicate = null)
        {
            var roleList = repos.GetAll().ToList();
            var roleViewModelList = roleList.Select(p => mapper.Map<Role, RoleViewModel>(p));
            if (predicate == null) return roleViewModelList.ToList();
            return roleViewModelList.AsQueryable().Where(predicate).ToList();
        }

        public bool Update(RoleViewModel model)
        {
            var roleObject = mapper.Map<RoleViewModel, Role>(model);
            Condition.Requires(roleObject).IsNotNull();

            return repos.Update(roleObject);
        }

        public bool Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
