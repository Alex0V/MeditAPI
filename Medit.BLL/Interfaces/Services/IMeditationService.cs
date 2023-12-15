using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;

namespace Medit.BLL.Interfaces.Services
{
    public interface IMeditationService
    {
        Task<IEnumerable<MeditationResponse>> GetAll();
        Task<MeditationResponse> GetById(int id);
        void Insert(MeditationRequest request);
        void Update(MeditationRequest request);
        void Delete(int id);
    }
}
