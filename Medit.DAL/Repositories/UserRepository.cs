using Medit.DAL.Context;
using Medit.DAL.Repositories.Base;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medit.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        protected readonly MeditDBContext context;

        public UserRepository(MeditDBContext dbContext) : base(dbContext)
        {
            context = dbContext;
        }

        public async Task<int> GetIdByUserName(string userName)
        {
            var user = await context.Users.FirstOrDefaultAsync(i => i.UserName == userName);
            return user.Id;
        }
    }
}
