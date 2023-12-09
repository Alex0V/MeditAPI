using AutoMapper;
using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using Medit.BLL.Interfaces.Services;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces;
using Medit.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.Services
{
    public class SessionService : ISessionService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ISessionRepository sessionRepository;


        public async Task<IEnumerable<SessionResponse>> GetAll()
        {
            var review = await sessionRepository.GetAll();
            return mapper.Map<List<SessionResponse>>(review);
        }
        public async Task<SessionResponse> GetById(int id)
        {
            var review = await sessionRepository.GetById(id);
            return mapper.Map<SessionResponse>(review);
        }

        public void Insert(SessionRequest request)
        {
            var review = mapper.Map<Session>(request);
            sessionRepository.Insert(review);
            unitOfWork.SaveChangesAsync();
        }

        public void Update(SessionRequest request)
        {
            var review = mapper.Map<Session>(request);
            sessionRepository.Update(review);
            unitOfWork.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            sessionRepository.Delete(id);
            unitOfWork.SaveChangesAsync();
        }

        public SessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.sessionRepository = this.unitOfWork.sessionRepository;
        }
    }
}
