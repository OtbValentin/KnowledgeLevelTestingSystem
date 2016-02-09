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
            if (isWeb)
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
                kernel.Bind<DbContext>().To<QuizFrameworkContext>().InRequestScope();
            }
            else
            {
                kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
                kernel.Bind<DbContext>().To<QuizFrameworkContext>().InSingletonScope();
            }

            kernel.Bind<IQuizService>().To<QuizService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IStatisticService>().To<StatisticService>();

            kernel.Bind<IQuizRepository>().To<QuizRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IRoleRepository>().To<RoleRepository>();
            kernel.Bind<IQuizStatisticRepository>().To<QuizStatisticRepository>();
        }
    }

    public class BindingModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IQuizService>().To<QuizService>();
            Bind<IRoleService>().To<RoleService>();
            Bind<IUserService>().To<UserService>();
            Bind<IStatisticService>().To<StatisticService>();

            Bind<IQuizRepository>().To<QuizRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IQuizStatisticRepository>().To<QuizStatisticRepository>();

            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            Bind<DbContext>().To<QuizFrameworkContext>().InRequestScope();
        }
    }
}
