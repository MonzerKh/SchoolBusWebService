using SchoolBusWebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusWebApi.Interface
{
    public interface IUnitOfWork
    {
        public ISystemUserRepository Users { get; }

        public IRoleRepository Roles { get;  }

        Task<bool> Complete();
        bool HasChanges();
    }
}
