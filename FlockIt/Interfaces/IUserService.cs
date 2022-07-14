using FlockIt.Entities;
using System.Threading.Tasks;

namespace FlockIt.Interfaces
{
    public interface IUserService
    {
        Task<User> Get(string username);
    }
}
