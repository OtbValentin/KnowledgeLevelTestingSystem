using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using BusinessLogicLayer.API.Entities;
using BusinessLogicLayer.API.Services;
using System.Web.Mvc;
using System.Web.Helpers;
using Ninject;
using DependenciesConfig;

namespace PresentationLayerWebMvc.CommonMembership
{
    public class CommonMembershipProvider : MembershipProvider
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

        public override bool EnablePasswordReset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool EnablePasswordRetrieval
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int MinRequiredPasswordLength
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int PasswordAttemptWindow
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string PasswordStrengthRegularExpression
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool RequiresUniqueEmail
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            MembershipUser user = GetUser(username, false);

            if (user == null)
            {
                User newUser = new User()
                {
                    PasswordHash = Crypto.HashPassword(password),
                    CreationDate = DateTime.Now,
                    Email = username,
                    Roles = new List<Role>() { new Role() { Name = "user" } }
                };

                //IKernel kernel = new StandardKernel(new BindingModule());
                //IUserService userService = kernel.Get<IUserService>();

                IUserService userService = DependencyResolver.Current.GetService<IUserService>();

                userService.Create(newUser);

                status = MembershipCreateStatus.Success;

                return new MembershipUser("CommonMembershipProvider", newUser.Email, newUser.Id, newUser.Email,
                null, null, true, false, newUser.CreationDate, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }
            
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            //IKernel kernel = new StandardKernel(new BindingModule());
            //IUserService userService = kernel.Get<IUserService>();

            IUserService userService = DependencyResolver.Current.GetService<IUserService>();

            User user = userService.GetByEmail(username);

            if (user == null)
            {
                return null;
            }

            return new MembershipUser("CommonMembershipProvider", username, user.Id, user.Email,
                null, null, true, false, user.CreationDate, DateTime.MinValue,
                DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);

        }

        public override bool ValidateUser(string username, string password)
        {
            if (username == null || password == null)
            {
                return false;
            }

            //IKernel kernel = new StandardKernel(new BindingModule());
            //IUserService userService = kernel.Get<IUserService>();

            IUserService userService = DependencyResolver.Current.GetService<IUserService>();

            User user = userService.GetByEmail(username);

            if (user == null || user.PasswordHash == null)
            {
                return false;
            }

            return Crypto.VerifyHashedPassword(user.PasswordHash, password);
        }

        public MembershipUserCollection GetAllUsers()
        {
            //IKernel kernel = new StandardKernel(new BindingModule());
            //IUserService userService = kernel.Get<IUserService>();

            IUserService userService = DependencyResolver.Current.GetService<IUserService>();

            MembershipUserCollection users = new MembershipUserCollection();

            foreach (User user in userService.GetAll())
            {
                users.Add(new MembershipUser("CommonMembershipProvider", user.Email, user.Id, user.Email, null,
                    null, true, true, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue));
            }

            return users;
        }

        #region Not implemented methods
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            totalRecords = 0;
            //throw new NotImplementedException();
            return GetAllUsers();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
