using AppNet.Services.Services;
using AppNet.Services.ViewModels;
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

        public ActionResult RoleCreate()
        {
            var model = new RoleViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult RoleCreate(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                roleService.Create(model);
                if (model.IsError)
                {
                    for (int i = 0; i < model.Errors.Count; i++)
                    {
                        ModelState.AddModelError("error" + i, model.Errors[i]);
                    }
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Roles");
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}