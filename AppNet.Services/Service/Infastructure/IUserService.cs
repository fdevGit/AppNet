﻿using AppNet.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.Service.Infastructure
{
    public interface IUserService : IBaseService<UserViewModel>
    {
        bool Login(UserViewModel model);
    }
}
