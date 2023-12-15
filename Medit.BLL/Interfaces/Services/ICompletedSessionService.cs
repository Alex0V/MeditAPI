using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Requests.CompletedSession;
using Medit.BLL.DTO.Responses;
using Medit.BLL.DTO.Responses.CompletedSession;

namespace Medit.BLL.Interfaces.Services
{
    public interface ICompletedSessionService
    {
        Task<IEnumerable<RecordsByTimeIntervalRespons>> GetRecordsByTimeInterval(string userName, string period);
        Task<IEnumerable<CompletedSessionResponse>> GetAll();
        Task Insert(AddCompletedSessionRequest request);
        Task Update(CompletedSessionRequest request);
        Task Delete(int userId, int sessionId);
    }
}
