using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.Interfaces.Services
{
    public interface ICompletedSessionService
    {
        Task<IEnumerable<CompletedSessionResponse>> GetAll();
        Task<CompletedSessionResponse> GetById(int id);
        void Insert(CompletedSessionRequest request);
        void Update(CompletedSessionRequest request);
        void Delete(int id);
    }
}
