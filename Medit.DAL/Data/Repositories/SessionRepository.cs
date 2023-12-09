using Medit.DAL.Context;
using Medit.DAL.Data.Repositories.Base;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.DAL.Data.Repositories
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        protected readonly MeditDBContext context;
        public SessionRepository(MeditDBContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
        public async Task<List<Session>> GetAllSession()
        {
            var list = await this.context.Set<Session>().ToListAsync();
            return list;
        }
    }
}
