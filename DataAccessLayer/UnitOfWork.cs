using DataAccessLayer.API;
using Ninject;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;
        private IRoleRepository roleRepository;
        private IUserRepository userRepository;
        private IQuizRepository testRepository;

        private bool disposed;

        public IRoleRepository RoleRepository
        {
            get
            {
                return roleRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                return userRepository;
            }
        }

        public IQuizRepository TestRepository
        {
            get
            {
                return testRepository;
            }
        }

        public UnitOfWork(DbContext context, IRoleRepository roleRepository,
            IUserRepository userRepository, IQuizRepository testRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.testRepository = testRepository;
        }
        public void Dispose()
        {
            Dispose(true);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposed = true;
            }
        }
    }
}
