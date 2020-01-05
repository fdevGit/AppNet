using AppNet.Services.Service.Infastructure;
using AppNet.Services.ViewModels;
using AppNet.WebApp.Attributes;
using AppNet.WebApp.ViewModel;
using CuttingEdge.Conditions;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AppNet.WebApp.Controllers
{
    public class AccountController : Controller
    {
        IRoleService roleService;
        IUserService userServices;

        public AccountController(IRoleService _roleService, IUserService _userService)
        {
            roleService = _roleService;
            userServices = _userService;
        }

        [AppAuthorize]
        public ActionResult Roles()
        {
            var model = roleService.GetAll();
            return View(model);
        }

        [AppAuthorize]
        public ActionResult UserEdit(int id)
        {
            var userModel = userServices.Get(id);
            Condition.Requires(userModel).IsNotNull();

            return View(userModel);
        }

        [HttpPost]
        public ActionResult UserEdit(UserViewModel model)
        {
            try
            {
                var userModel = userServices.Update(model);
                Condition.Requires(userModel).IsTrue();
                return RedirectToAction("Users");
            }
            catch (Exception)
            {

                return View(model);
            }
        }

        [AppAuthorize]
        public ActionResult UserDelete(int id)
        {
            var userModel = userServices.Delete(id);
            Condition.Requires(userModel).IsTrue();

            return View(userModel);
        }

        [HttpPost]
        public ActionResult UserDelete(UserViewModel model)
        {
            try
            {
                var userModel = userServices.Delete(model);
                Condition.Requires(userModel).IsTrue();
                return RedirectToAction("Users");
            }
            catch (Exception)
            {

                return View(model);
            }
        }

        [AppAuthorize]
        public ActionResult GetUser(int id)
        {
            var userModel = userServices.Delete(id);
            Condition.Requires(userModel).IsTrue();

            return View(userModel);
        }

        [HttpPost]
        public ActionResult GetUser(UserViewModel model)
        {
            try
            {
                var userModel = userServices.Get(model.Id);
                Condition.Requires(userModel).IsNotNull();
                return RedirectToAction("Users");
            }
            catch (Exception)
            {

                return View(model);
            }
        }

        [AppAuthorize]
        public ActionResult RoleEdit(int id)
        {
            var roleModel = roleService.Get(id);
            Condition.Requires(roleModel).IsNotNull();

            return View(roleModel);
        }

        [HttpPost]
        public ActionResult RoleEdit(RoleViewModel model)
        {
            try
            {
                var roleModel = roleService.Update(model);
                Condition.Requires(roleModel).IsTrue();
                return RedirectToAction("Roles");
            }
            catch (Exception)
            {

                return View(model);
            }
        }

        [AppAuthorize]
        public ActionResult RoleView(int id)
        {
            var roleModel = roleService.Get(id);
            Condition.Requires(roleModel).IsNotNull();

            return View(roleModel);
        }

        [AppAuthorize]
        public ActionResult RoleDelete(int id)
        {
            var roleModel = roleService.Get(id);
            Condition.Requires(roleModel).IsNotNull();

            return View(roleModel);
        }

        [HttpPost]
        public ActionResult RoleDelete(RoleViewModel model)
        {
            try
            {
                var roleModel = roleService.Delete(model);
                Condition.Requires(roleModel).IsTrue();
                return RedirectToAction("Roles");
            }
            catch (Exception)
            {

                return View(model);
            }
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

            //int sayi = 50;
            //string adi = "admn";

            //Condition.Requires(adi).Contains(" ").IsNullOrEmpty().HasLength(20).IsNotEmpty().StartsWith("a");

            //Condition.Requires(sayi).IsInRange(0, 20);

            try
            {
                Condition.Requires(ModelState.IsValid).IsTrue("Model");

                roleService.Create(model);
                Condition.Requires(model.IsError).IsFalse("create Error");
                for (int i = 0; i < model.Errors.Count; i++)
                {
                    ModelState.AddModelError("error" + i, model.Errors[i]);
                }
                return RedirectToAction("Roles");

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                return View(model);
            }
        }

        [AppAuthorize]
        public ActionResult Users()
        {
            var model = userServices.GetAll();
            return View(model);
        }
        [AppAuthorize]
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

        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            List<string> x = new List<string>();

            x.ForEach(t => { });


            try
            {
                Condition.Requires(model.EmailAddress).IsNotNull().Contains("@").Contains(".").IsLongerOrEqual(10);
                Condition.Requires(model.Password).IsNotNull().IsLongerOrEqual(5);

                var loginResult = userServices.Login(new UserViewModel() { UserName = model.EmailAddress, Password = model.Password });

                Condition.Requires(loginResult).IsTrue();

                return RedirectToAction("Roles");
            }
            catch (Exception)
            {
                return View(model);
            }
        }
    }
}