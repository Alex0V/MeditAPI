using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.Interfaces.Services
{
    public interface ISessionGroupService
    {
        Task<IEnumerable<SessionGroupResponse>> GetAll();
        Task<SessionGroupResponse> GetById(int id);
        void Insert(SessionGroupRequest request);
        void Update(SessionGroupRequest request);
        void Delete(int id);
    }
}
