﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime ModifyOn { get; set; }
        public DateTime CreateOn { get; set; }
        public string[] RoleNames { get; set; }
    }

}
