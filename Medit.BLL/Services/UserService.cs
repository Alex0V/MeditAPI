using AutoMapper;
using Medit.BLL.DTO.Requests;
using Medit.BLL.DTO.Responses;
using Medit.BLL.Interfaces.Services;
using Medit.DAL.Entities;
using Medit.DAL.Interfaces.Repositories;

namespace Medit.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;

        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var review = await userRepository.GetAll();
            return mapper.Map<List<UserResponse>>(review);
        }
        public async Task<UserResponse> GetById(int id)
        {
            var review = await userRepository.GetById(id);
            return mapper.Map<UserResponse>(review);
        }

        public void Insert(UserRequest request)
        {
            var review = mapper.Map<User>(request);
            userRepository.Insert(review);
        }

        public void Update(UserRequest request)
        {
            var review = mapper.Map<User>(request);
            userRepository.Update(review);
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
    }
}
