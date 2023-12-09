using AutoMapper;
using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using Medit.BLL.Interfaces.Services;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces;
using Medit.DAL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medit.BLL.Services
{
    public class CompletedSessionService : ICompletedSessionService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ICompletedSessionRepository completedSessionRepository;


        public async Task<IEnumerable<CompletedSessionResponse>> GetAll()
        {
            var review = await completedSessionRepository.GetAll();
            return mapper.Map<List<CompletedSessionResponse>>(review);
        }
        public async Task<CompletedSessionResponse> GetById(int id)
        {
            var review = await completedSessionRepository.GetById(id);
            return mapper.Map<CompletedSessionResponse>(review);
        }

        public void Insert(CompletedSessionRequest request)
        {
            var review = mapper.Map<CompletedSession>(request);
            completedSessionRepository.Insert(review);
            unitOfWork.SaveChangesAsync();
        }

        public void Update(CompletedSessionRequest request)
        {
            var review = mapper.Map<CompletedSession>(request);
            completedSessionRepository.Update(review);
            unitOfWork.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            completedSessionRepository.Delete(id);
            unitOfWork.SaveChangesAsync();
        }

        public CompletedSessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            completedSessionRepository = this.unitOfWork.completedSessionRepository;
        }
    }
}
