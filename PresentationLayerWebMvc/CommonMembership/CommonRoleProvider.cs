using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using System.Web.Mvc;
using Ninject;
using DependenciesConfig;

namespace PresentationLayerWebMvc.CommonMembership
{
    public class CommonRoleProvider : RoleProvider
    {
        #region Not implemented properties
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        public override void CreateRole(string roleName)
        {
            if (!string.IsNullOrEmpty(roleName))
            {
                Role role = new Role() { Name = roleName, Description = roleName };

                //IKernel kernel = new StandardKernel(new BindingModule());
                //IRoleService roleService = kernel.Get<IRoleService>();

                IRoleService roleService = DependencyResolver.Current.GetService<IRoleService>();

                roleService.Create(role);
            }
        }

        public override bool RoleExists(string roleName)
        {
            //IKernel kernel = new StandardKernel(new BindingModule());
            //IRoleService roleService = kernel.Get<IRoleService>();

            IRoleService roleService = DependencyResolver.Current.GetService<IRoleService>();

            Role role = roleService.GetRoleByName(roleName);

            if (role == null)
            {
                return false;
            }

            return true;
        }

        public override string[] GetAllRoles()
        {
            //IKernel kernel = new StandardKernel(new BindingModule());
            //IRoleService roleService = kernel.Get<IRoleService>();

            IRoleService roleService = DependencyResolver.Current.GetService<IRoleService>();

            return roleService.GetAll().Select(role => role.Name).ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            //IKernel kernel = new StandardKernel(new BindingModule());
            //IUserService userService = kernel.Get<IUserService>();

            IUserService userService = DependencyResolver.Current.GetService<IUserService>();

            User user = userService.GetByEmail(username);

            if (user == null)
            {
                return new string[0];
            }

            return userService.GetByEmail(username).Roles.Select(role => role.Name).ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return GetRolesForUser(username).Contains(roleName);
        }

        #region Not implemented methods
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
