using AppNet.Domain.Models;
using AppNet.Services.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.Configurations
{
    public class MapperConfig
    {
        public static void UserToViewModel()
        {

        }
        public static MapperConfiguration Configure()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<UserViewModel, User>();
                cfg.CreateMap<Role, RoleViewModel>()
                    .ForMember(p=>p.ModifiedOn,c=>c.MapFrom(x=>x.ModifyOn))
                    .ForMember(p=>p.CreatedOn,c=>c.MapFrom(x=>x.CreateOn))
                    .ReverseMap();
                //.ForMember(t => t.Nane, t => t.MapFrom(c => c.Password))
                //.AfterMap(UserToViewModel<User, UserViewModel>())
            });
            //configuration.AssertConfigurationIsValid();
            return configuration;
            //var mapper = new Mapper(configuration);
            //var userObject = new User() { Name = "Adminx" };

            //var data = mapper.Map<User, UserViewModel>(userObject);
        }
    }
}
