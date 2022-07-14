using FlockIt.Data;
using FlockIt.Entities;
using FlockIt.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ApiTestProject
{
    public class UnitTest
    {
        private DbContextOptions<DataContext> dbContextOptions;

        public UnitTest()
        {
            var dbName = $"FlockitDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<DataContext>().UseInMemoryDatabase(dbName).Options;
        }

        [Fact]
        public async Task GetUserAsync_Success_Test()
        {
            var repository = await CreateRepositoryAsync();

            // Act
            var user = await repository.Get("Carlos");

            // Assert
            Assert.Equal("Carlos", user.Name);
        }

        private async Task<UserRepository> CreateRepositoryAsync()
        {
            var context = new DataContext(dbContextOptions);
            await PopulateDataAsync(context);
            return new UserRepository(context);
        }

        private async Task PopulateDataAsync(DataContext context)
        {
            var author = new User()
            {
                Name = "Carlos",
                Password = "1234"
            };

            await context.Users.AddAsync(author);
            

            await context.SaveChangesAsync();
        }
    }

}
