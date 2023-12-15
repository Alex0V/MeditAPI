using Medit.DAL.Entities;
using Medit.DAL.Entities.HelpModel;
using Medit.DAL.Interfaces.Repositories.Base;

namespace Medit.DAL.Interfaces.Repositories
{
    public interface ICompletedSessionRepository
    {
        Task<List<CompletedSession>> GetAllForDay(int userId, DateTime currentDate);
        Task<List<CompletedSession>> GetAllForWeek(int userId, DateTime currentDate);
        Task<List<CompletedSession>> GetAllForMonth(int userId, DateTime currentDate);
        Task<List<CombinedDataModel>> getJoinedTables(List<CompletedSession> fetchedSessions);

        Task<List<CompletedSession>> GetAll();
        Task Insert(CompletedSession completedSession);
        Task Update(CompletedSession completedSession);
        Task Delete(int userId, int sessionId);
    }
}
