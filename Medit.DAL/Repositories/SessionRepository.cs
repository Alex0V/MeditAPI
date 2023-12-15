using Medit.DAL.Context;
using Medit.DAL.Repositories.Base;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medit.DAL.Repositories
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
            var list = await context.Set<Session>().ToListAsync();
            return list;
        }
    }
}
