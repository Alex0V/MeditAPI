using Medit.DAL.Context;
using Medit.DAL.Data.Repositories.Base;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MeditDBContext dbContext) : base(dbContext)
        {
        }
    }
}
