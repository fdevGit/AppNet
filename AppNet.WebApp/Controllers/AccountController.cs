using AppNet.Services.Service;
using AppNet.Services.ViewModels;
using AppNet.WebApp.Attributes;
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
        UserServices userServices;

        public AccountController()
        {
            roleService = new RoleService();
            userServices = new UserServices();
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //base.OnActionExecuted(filterContext);
            //if (filterContext == null && filterContext.ActionDescriptor.ActionName != "Login")
            //{
            //    RedirectToAction("Login");
            //}
        }

        [AppAuthorize]
        public ActionResult Roles()
        {
            var model = roleService.GetAll();
            return View(model);
        }
        [AppAuthorize]
        public ActionResult RoleCreate()
        {
            var model = new RoleViewModel();
            return View(model);
        }

        [AppAuthorize]
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

        public ActionResult Users()
        {
            var model = userServices.GetAll();
            return View(model);
        }

        public ActionResult UserCreate()
        {
            var model = new UserViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult UserCreate(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                userServices.Create(model);
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
                    return RedirectToAction("Users");
                }
            }
            else
            {
                return View(model);
            }
        }
    }
}