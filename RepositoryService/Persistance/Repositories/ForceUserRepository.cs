using Entities;
using MyDatabase;
using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Persistance.Repositories
{
    public class ForceUserRepository : GenericRepository<ForceUser>, IForceUserRepository
    {
        public ForceUserRepository(ApplicationDbContext context) :base(context)
        {

        }
    }
}
