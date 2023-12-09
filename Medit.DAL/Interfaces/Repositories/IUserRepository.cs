using Medit.DAL.Entities;
using Medit.DAL.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
