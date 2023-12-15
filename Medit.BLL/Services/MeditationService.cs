using AutoMapper;
using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using Medit.BLL.Interfaces.Services;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces;
using Medit.DAL.Interfaces.Repositories;

namespace Medit.BLL.Services
{
    public class MeditationService : IMeditationService
    {
        private readonly IMapper mapper;

        private readonly IMeditationRepository meditationRepository;

        public async Task<IEnumerable<MeditationResponse>> GetAll()
        {
            var review = await meditationRepository.GetAll();
            return mapper.Map<List<MeditationResponse>>(review);
        }
        public async Task<MeditationResponse> GetById(int id)
        {
            var review = await meditationRepository.GetById(id);
            return mapper.Map<MeditationResponse>(review);
        }

        public void Insert(MeditationRequest request)
        {
            var review = mapper.Map<Meditation>(request);
            meditationRepository.Insert(review);
        }

        public void Update(MeditationRequest request)
        {
            var review = mapper.Map<Meditation>(request);
            meditationRepository.Update(review);
        }

        public void Delete(int id)
        {
            meditationRepository.Delete(id);
        }

        public MeditationService(IMeditationRepository meditationRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.meditationRepository = meditationRepository;
        }
    }
}
