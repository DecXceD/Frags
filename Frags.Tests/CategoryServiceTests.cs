using Frags.Data.Models;
using Frags.Services.Services;
using Frags.Services.ViewModels.Category;

namespace Frags.Tests
{
    public class CategoryServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddCategory()
        {
            var context = TestDbContextFactory.Create();
            var service = new CategoryService(context);

            await service.CreateAsync(new CategoryFormModel { Name = "Test" });

            Assert.Single(context.Categories);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnCategories()
        {
            var context = TestDbContextFactory.Create();
            context.Categories.Add(new Category { Name = "Test" });
            context.SaveChanges();

            var service = new CategoryService(context);

            var result = await service.GetAllAsync();

            Assert.Single(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveCategory()
        {
            var context = TestDbContextFactory.Create();
            context.Categories.Add(new Category { Id = 1, Name = "Test" });
            context.SaveChanges();

            var service = new CategoryService(context);

            await service.DeleteAsync(1);

            Assert.Empty(context.Categories);
        }
    }
}
