using AppNet.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AppNet.Services.Service.Managers
{
    public class UserManager
    {
        public static UserViewModel ActiveUser
        {
            get
            {
                return HttpContext.Current.Session["ActiveUser"] as UserViewModel;
            }
            set
            {
                HttpContext.Current.Session["ActiveUser"] = value;
            }
        }
    }
}
