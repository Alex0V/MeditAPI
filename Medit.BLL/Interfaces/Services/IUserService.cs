using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.Interfaces.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetAll();
        Task<UserResponse> GetById(int id);
        void Insert(UserRequest request);
        void Update(UserRequest request);
        void Delete(int id);
    }
}
