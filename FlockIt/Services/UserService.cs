using FlockIt.Entities;
using FlockIt.Interfaces;
using System.Threading.Tasks;

namespace FlockIt.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> Get(string username)
        {
           return await _userRepository.Get(username);
        }
    }
}
