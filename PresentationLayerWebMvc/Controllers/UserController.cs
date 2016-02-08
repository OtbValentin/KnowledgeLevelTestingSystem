using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using PresentationLayerWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PresentationLayerWebMvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        //[Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            string delimeter = " ";
            IEnumerable<User> users = userService.GetAll();

            IEnumerable<UserDisplayViewModel> displayUsers = users.Select(u => new UserDisplayViewModel()
            {
                Id = u.Id,
                CreationDate = u.CreationDate,
                Username = u.Email,
                Roles = u.Roles.Select(role => string.Format("{0} ", role.Name)).Aggregate((i, j) => string.Format("{0}{1}{2}", i, delimeter, j))
            });

            return View(displayUsers);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}