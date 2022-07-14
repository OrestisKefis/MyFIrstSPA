using MyDatabase;
using RepositoryService.Core;
using RepositoryService.Core.Repositories;
using RepositoryService.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public IForceUserRepository ForceUsers { get; private set; }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            context = dbContext;
            ForceUsers = new ForceUserRepository(context);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
