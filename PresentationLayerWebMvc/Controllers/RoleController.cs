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
        // GET: Rolee
        public ActionResult Index()
        {
            IEnumerable<Role> roles = roleService.GetAll();

            IEnumerable<RoleDisplayViewModel> roleViews = roles.Select(r => new RoleDisplayViewModel()
            { Id = r.Id, Name = r.Name, Description = r.Description });

            return View(roleViews);
        }

        // GET: Rolee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rolee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rolee/Create
        [HttpPost]
        public ActionResult Create(RoleCreateViewModel role)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    roleService.Create(new Role() { Name = role.Name, Description = role.Description });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Rolee/Edit/5
        public ActionResult Edit(int id)
        {
            Role role = roleService.GetById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(new RoleEditViewModel() { Name = role.Name, Description = role.Description });
        }

        // POST: Rolee/Edit/5
        [HttpPost]
        public ActionResult Edit(RoleEditViewModel role)
        {
            try
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
            catch
            {
                return View();
            }
        }

        // GET: Rolee/Delete/5
        public ActionResult Delete(int id)
        {
            Role role = roleService.GetById(id);

            if (role == null)
            {
                return HttpNotFound();
            }

            return View(new RoleDisplayViewModel() { Id = role.Id, Name = role.Name, Description = role.Description });
        }

        // POST: Rolee/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                Role role = roleService.GetById(id);

                if (role == null)
                {
                    return HttpNotFound();
                }

                roleService.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
