using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
