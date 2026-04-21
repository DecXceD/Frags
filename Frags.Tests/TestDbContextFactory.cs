using Frags.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Frags.Tests
{
    public static class TestDbContextFactory
    {
        public static FragsDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FragsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new FragsDbContext(options);
        }
    }
}