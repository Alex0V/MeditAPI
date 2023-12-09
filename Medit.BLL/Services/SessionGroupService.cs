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
    public class SessionGroupService : ISessionGroupService
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly IMapper mapper;

        private readonly ISessionGroupRepository sessionGroupRepository;


        public async Task<IEnumerable<SessionGroupResponse>> GetAll()
        {
            var review = await sessionGroupRepository.GetAll();
            return mapper.Map<List<SessionGroupResponse>>(review);
        }
        public async Task<SessionGroupResponse> GetById(int id)
        {
            var review = await sessionGroupRepository.GetById(id);
            return mapper.Map<SessionGroupResponse>(review);
        }

        public void Insert(SessionGroupRequest request)
        {
            var review = mapper.Map<SessionGroup>(request);
            sessionGroupRepository.Insert(review);
            unitOfWork.SaveChangesAsync();
        }

        public void Update(SessionGroupRequest request)
        {
            var review = mapper.Map<SessionGroup>(request);
            sessionGroupRepository.Update(review);
            unitOfWork.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            sessionGroupRepository.Delete(id);
            unitOfWork.SaveChangesAsync();
        }

        public SessionGroupService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.sessionGroupRepository = this.unitOfWork.sessionGroupRepository;
        }
    }
}
