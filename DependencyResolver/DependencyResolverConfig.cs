using DataAccessLayer;
using DataAccessLayer.API;
using Ninject;
using Ninject.Web.Common;
using ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessLogicLayer.API.Services;
using BusinessLogicLayer.Services;

namespace DependenciesConfig
{
    public static class DependencyResolverConfig
    {
        public static void ConfigurateResolverWeb(this IKernel kernel)
        {
            Configure(kernel, true);
        }

        public static void ConfigurateResolverConsole(this IKernel kernel)
        {
            Configure(kernel, false);
        }

        private static void Configure(IKernel kernel, bool isWeb)
        {
            //if (isWeb)
            //{
            //    kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            //    kernel.Bind<DbContext>().To<TestingSystemContext>().InRequestScope();
            //}
            //else
            //{
            //    kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            //    kernel.Bind<DbContext>().To<TestingSystemContext>().InSingletonScope();
            //}

            kernel.Load(new BindingModule());
        }
    }

    public class BindingModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IQuizService>().To<QuizService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IUserService>().To<UserService>();

            Bind<IQuizRepository>().To<QuizRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();

            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            Bind<DbContext>().To<QuizFrameworkContext>().InRequestScope();
        }
    }
}
