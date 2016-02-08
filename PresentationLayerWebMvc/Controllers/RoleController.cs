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

            IEnumerable<RoleDisplayViewModel> roleViews = roles.Select(r => new RoleDisplayViewModel()
            { Id = r.Id, Name = r.Name, Description = r.Description });

            return View(roleViews);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RoleDisplayViewModel role)
        {
            if (ModelState.IsValid)
            {
                roleService.Create(new Role() { Name = role.Name, Description = role.Description });
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Role role = roleService.GetById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(new RoleEditViewModel() { Name = role.Name, Description = role.Description });
        }

        [HttpPost]
        public ActionResult Edit(RoleEditViewModel role)
        {
            Role roleToEdit = roleService.GetById(role.Id);

            if (role == null)
            {
                return HttpNotFound();
            }

            roleToEdit.Name = role.Name;
            roleToEdit.Description = role.Description;
            roleService.Update(roleToEdit);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Role role = roleService.GetById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(new RoleDisplayViewModel() { Id = role.Id, Name = role.Name, Description = role.Description });
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = roleService.GetById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            roleService.Delete(role);

            return RedirectToAction("Index");
        }
    }
}