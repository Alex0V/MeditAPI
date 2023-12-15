using AutoMapper;
using Medit.DAL.Entities;
using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using Medit.BLL.DTO.Responses.CompletedSession;
using Medit.DAL.Entities.HelpModel;
using Medit.BLL.DTO.Requests.CompletedSession;

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
            CreateMap<CombinedDataModel, RecordsByTimeIntervalRespons>()
                .ForMember(dest => dest.CompletedDateTime, opt => opt.MapFrom(src => src.CompletedSession.AuditionDate))
                .ForMember(dest => dest.SessionName, opt => opt.MapFrom(src => src.Session.SessionName))
                .ForMember(dest => dest.Meditation, opt => opt.MapFrom(src => src.Meditation.Name));
            CreateMap<AddCompletedSessionRequest, CompletedSession>()
                .ForMember(dest => dest.SessionId, opt => opt.MapFrom(src => src.SessionId));
        }

        private void CreateMeditationMaps()
        {
            CreateMap<Meditation, MeditationResponse>();
            CreateMap<MeditationRequest, Meditation>();
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
            CreateMeditationMaps();
            CreateSessionMaps();
        }

    }
}
