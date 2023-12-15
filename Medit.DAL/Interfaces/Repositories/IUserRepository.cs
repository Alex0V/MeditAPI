using Medit.DAL.Entities;
using Medit.DAL.Interfaces.Repositories.Base;

namespace Medit.DAL.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<int> GetIdByUserName(string userName);
    }
}
