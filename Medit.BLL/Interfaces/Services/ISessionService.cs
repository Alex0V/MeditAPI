using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;

namespace Medit.BLL.Interfaces.Services
{
    public interface ISessionService
    {
        Task<IEnumerable<SessionResponse>> GetAll();
        Task<SessionResponse> GetById(int id);
        void Insert(SessionRequest request);
        void Update(SessionRequest request);
        void Delete(int id);
    }
}
