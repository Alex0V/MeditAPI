using Medit.DAL.Context;
using Medit.DAL.Entities;
using Medit.DAL.Entities.HelpModel;
using Medit.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medit.DAL.Repositories
{
    public class CompletedSessionRepository : ICompletedSessionRepository
    {
        protected readonly MeditDBContext context;
        public CompletedSessionRepository(MeditDBContext dbContext)
        {
            this.context = dbContext;
        }

        public async Task<List<CompletedSession>> GetAllForDay(int userId, DateTime currentDate)
        {
            return await context.CompletedSessions
                    .Where(s => s.UserId == userId && s.AuditionDate >= currentDate.AddDays(-1))
                    .ToListAsync();

        }
        public async Task<List<CompletedSession>> GetAllForWeek(int userId, DateTime currentDate)
        {
            return await context.CompletedSessions
                    .Where(s => s.UserId == userId && s.AuditionDate >= currentDate.AddDays(-7))
                    .ToListAsync();
        }
        public async Task<List<CompletedSession>> GetAllForMonth(int userId, DateTime currentDate)
        {
            return await context.CompletedSessions
                    .Where(s => s.UserId == userId && s.AuditionDate >= currentDate.AddMonths(-1))
                    .ToListAsync();
        }

        public async Task<List<CombinedDataModel>> getJoinedTables(List<CompletedSession> fetchedSessions)
        {
            var allData = await context.CompletedSessions
                .Include(cs => cs.Sessions)
                .ThenInclude(s => s.Meditation)
                .ToListAsync();
            var filteredData = allData
                .Where(data => fetchedSessions.Any(cs => cs.SessionId == data.SessionId) &&
                               fetchedSessions.Any(cs => cs.UserId == data.UserId) &&
                               fetchedSessions.Any(cs => cs.Id == data.Id))
                .Select(cs => new CombinedDataModel
                {
                    CompletedSession = cs,
                    Session = cs.Sessions,
                    Meditation = cs.Sessions.Meditation
                })
                .ToList();
            return filteredData;
        }

        public async Task<List<CompletedSession>> GetAll()
        {
            return await context.CompletedSessions.ToListAsync();
        }

        public async Task Insert(CompletedSession completedSession)
        {
            context.CompletedSessions.Add(completedSession);
            await context.SaveChangesAsync();
        }


        public async Task Update(CompletedSession completedSession)
        {
            var existingCompletedSession = context.CompletedSessions.FirstOrDefault(cs => cs.UserId == completedSession.UserId && cs.SessionId == completedSession.SessionId);

            if (existingCompletedSession != null)
            {
                existingCompletedSession.AuditionDate = completedSession.AuditionDate;
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int userId, int sessionId)
        {
            var completedSessionToDelete = context.CompletedSessions.FirstOrDefault(cs => cs.UserId == userId && cs.SessionId == sessionId);

            if (completedSessionToDelete != null)
            {
                context.CompletedSessions.Remove(completedSessionToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}
