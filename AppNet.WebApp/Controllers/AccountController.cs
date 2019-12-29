using AppNet.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppNet.WebApp.Controllers
{
    public class AccountController : Controller
    {
        RoleService roleService;

        public AccountController()
        {
            roleService = new RoleService();
        }

        // GET: Account
        public ActionResult Roles()
        {
            var model = roleService.GetAll();
            return View(model);
        }
    }
}