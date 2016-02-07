using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using PresentationLayerWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PresentationLayerWebMvc.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService roleService;

        public RoleController(IRoleService roleService)
        {
            this.roleService = roleService;
        }
        // GET: Role
        public ActionResult Index()
        {
            IEnumerable<Role> roles = roleService.GetAll();

            IEnumerable<RoleViewModel> roleViews = roles.Select(r => new RoleViewModel() { Id = r.Id, Name = r.Name });

            return View(roleViews);
        }
    }
}