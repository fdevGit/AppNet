using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Services.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Nane { get; set; }
        public string[] RoleNames { get; set; }
    }

}
