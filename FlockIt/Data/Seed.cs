using FlockIt.Entities;
using FlockIt.Interfaces;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlockIt.Data
{
    public class Seed
    {
        public static async Task SeedUsers(IUserRepository userRepository)
        {
            if (await userRepository.Get("Javier") != null) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var user = JsonSerializer.Deserialize<User>(userData);
            
            if (user == null) return;

            await userRepository.Add(user);
         }
    }
}
