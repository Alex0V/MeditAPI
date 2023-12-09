using AutoMapper;
using Medit.DAL.Entities;
using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using System;

namespace Medit.BLL.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        private void CreateUserMaps()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>();
        }

        private void CreateCompletedSessionMaps()
        {
            CreateMap<CompletedSession, CompletedSessionResponse>();
            CreateMap<CompletedSessionRequest, CompletedSession>();
        }

        private void CreateSessionGroupMaps()
        {
            CreateMap<SessionGroup, SessionGroupResponse>();
            CreateMap<SessionGroupRequest, SessionGroup>();
        }

        private void CreateSessionMaps()
        {
            CreateMap<Session, SessionResponse>();
            CreateMap<SessionRequest, Session>();
        }

        public AutoMapperProfile()
        {
            CreateUserMaps();
            CreateCompletedSessionMaps();
            CreateSessionGroupMaps();
            CreateSessionMaps();
        }

    }
}
