using FlockIt.Data;
using FlockIt.Entities;
using FlockIt.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FlockIt.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> Get(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Name == username);
        }

        public async Task<User> Add(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

    }
}
