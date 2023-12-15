using AutoMapper;
using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Requests.CompletedSession;
using Medit.BLL.DTO.Responses;
using Medit.BLL.DTO.Responses.CompletedSession;
using Medit.BLL.Interfaces.Services;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces;
using Medit.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Medit.BLL.Services
{
    public class CompletedSessionService : ICompletedSessionService
    {
        private readonly IMapper mapper;

        private readonly ICompletedSessionRepository completedSessionRepository;
        private readonly IUserRepository userRepository;

        public async Task<IEnumerable<RecordsByTimeIntervalRespons>> GetRecordsByTimeInterval(string userName, string period)
        {
            int userId = await this.userRepository.GetIdByUserName(userName.ToString());
            DateTime currentDate = DateTime.Now;
            List<CompletedSession> fetchedSessions = new List<CompletedSession>();

            if (period == "day")
            {
                fetchedSessions = await this.completedSessionRepository.GetAllForDay(userId, currentDate);
            }
            else if (period == "week")
            {
                fetchedSessions = await this.completedSessionRepository.GetAllForWeek(userId, currentDate);
            }
            else if (period == "month")
            {
                fetchedSessions = await this.completedSessionRepository.GetAllForMonth(userId, currentDate);
            }

            var completedSessions = await this.completedSessionRepository.getJoinedTables(fetchedSessions);

            return mapper.Map<List<RecordsByTimeIntervalRespons>>(completedSessions);
        }

        public async Task<IEnumerable<CompletedSessionResponse>> GetAll()
        {
            var review = await completedSessionRepository.GetAll();
            return mapper.Map<List<CompletedSessionResponse>>(review);
        }

        public async Task Insert(AddCompletedSessionRequest request)
        {

            int userId = await this.userRepository.GetIdByUserName(request.UserName);
            DateTime currentDate = DateTime.Now;

            var review = mapper.Map<CompletedSession>(request);
            review.UserId = userId;
            review.AuditionDate = currentDate;
            completedSessionRepository.Insert(review);
        }

        public async Task Update(CompletedSessionRequest request)
        {
            var review = mapper.Map<CompletedSession>(request);
            await completedSessionRepository.Update(review);
        }

        public async Task Delete(int userId, int sessionId)
        {
            await completedSessionRepository.Delete(userId, sessionId);
        }

        public CompletedSessionService(ICompletedSessionRepository completedSessionRepository, IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.completedSessionRepository = completedSessionRepository;
            this.userRepository = userRepository;
        }
    }
}
