using Medit.DAL.Interfaces.Entities;

namespace Medit.DAL.Interfaces.Repositories.Base
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T obj);
        void Update(T obj);
        void Delete(int id);

    }
}
