using FlockIt.Entities;
using System.Threading.Tasks;

namespace FlockIt.Interfaces
{
    public interface IGeoService
    {
        Task<State> GetStateGeo(string stateName);
    }
}
