using FlockIt.Entities;
using System.Threading.Tasks;

namespace FlockIt.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
