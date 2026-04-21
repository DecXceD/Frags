using Frags.Data.Models;
using Frags.Services.Services;
using Frags.Services.ViewModels.Brand;

namespace Frags.Tests
{
    public class BrandServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldAddBrand()
        {
            var context = TestDbContextFactory.Create();
            var service = new BrandService(context);

            await service.CreateAsync(new BrandFormModel { Name = "Test" });

            Assert.Single(context.Brands);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnBrands()
        {
            var context = TestDbContextFactory.Create();
            context.Brands.Add(new Brand { Name = "Test" });
            context.SaveChanges();

            var service = new BrandService(context);

            var result = await service.GetAllAsync();

            Assert.Single(result);
        }

        [Fact]
        public async Task EditAsync_ShouldUpdateBrand()
        {
            var context = TestDbContextFactory.Create();
            context.Brands.Add(new Brand { Id = 1, Name = "Old" });
            context.SaveChanges();

            var service = new BrandService(context);

            await service.EditAsync(new BrandFormModel { Id = 1, Name = "New" });

            Assert.Equal("New", context.Brands.First().Name);
        }

        [Fact]
        public async Task EditAsync_ShouldThrow_WhenNotFound()
        {
            var context = TestDbContextFactory.Create();
            var service = new BrandService(context);

            await Assert.ThrowsAsync<ArgumentException>(() =>
                service.EditAsync(new BrandFormModel { Id = 999, Name = "Test" }));
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveBrand()
        {
            var context = TestDbContextFactory.Create();
            context.Brands.Add(new Brand { Id = 1, Name = "Test" });
            context.SaveChanges();

            var service = new BrandService(context);

            await service.DeleteAsync(1);

            Assert.Empty(context.Brands);
        }
    }
}
