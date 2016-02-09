using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using PresentationLayerWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerWebMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            this.userService = userService;
            this.roleService = roleService;
        }
 
        public ActionResult Index()
        {
            string delimeter = " ";
            IEnumerable<User> users = userService.GetAll();

            IEnumerable<UserDisplayViewModel> displayUsers = users.Select(u => new UserDisplayViewModel()
            {
                Id = u.Id,
                CreationDate = u.CreationDate,
                Username = u.Email,
                Roles = ConcatStrings(u.Roles.Select(r => r.Name), delimeter)
            });

            return View(displayUsers);
        }

        private string ConcatStrings(IEnumerable<string> strings, string delimiter)
        {
            StringBuilder resultString = new StringBuilder();

            foreach (string item in strings)
            {
                resultString.Append(string.Format("{0}{1}", item, delimiter));
            }

            return resultString.ToString();
        }

        public ActionResult Edit(int id)
        {
            User user = userService.GetById(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            MultiSelectList roles = new MultiSelectList(roleService.GetAll().Select(role => role.Name));

            UserEditViewModel userModel = new UserEditViewModel()
            { Id = user.Id, Username = user.Email, Roles = user.Roles.Select(r => r.Name).ToList() };

            ViewBag.Roles = roles;

            return View(userModel);
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = userService.GetById(userModel.Id);

                    if (user != null)
                    {
                        user.Email = userModel.Username;
                        user.Roles = userModel.Roles.Select(s => roleService.GetRoleByName(s)).ToList();
                        userService.Update(user);
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            User user = userService.GetById(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(new UserDeleteViewModel() { Id = user.Id, Email = user.Email });
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                User user = userService.GetById(id);

                if (user == null)
                {
                    return HttpNotFound();
                }

                userService.Delete(user.Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
