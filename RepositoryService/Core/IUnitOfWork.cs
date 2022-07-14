using RepositoryService.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryService.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IForceUserRepository ForceUsers { get; }
    }
}
