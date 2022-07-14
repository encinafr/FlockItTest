using FlockIt.Entities;
using System.Threading.Tasks;

namespace FlockIt.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Get(string username);
        Task<User> Add(User user );
    }
}
