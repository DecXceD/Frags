using Frags.Data.Data;
using Frags.Data.Models;
using Frags.Services.Interfaces;
using Frags.Services.Services;
using Frags.Services.ViewModels.Fragrance;
using Moq;

namespace Frags.Tests
{
    public class FragranceServiceTests
    {
        private static FragranceService CreateService(FragsDbContext context)
        {
            return new FragranceService(
                context,
                new Mock<IBrandService>().Object,
                new Mock<ICategoryService>().Object);
        }

        private static void SeedBrandCategory(FragsDbContext context)
        {
            context.Brands.Add(new Brand { Id = 1, Name = "Brand" });
            context.Categories.Add(new Category { Id = 1, Name = "Category" });
            context.SaveChanges();
        }

        [Fact]
        public async Task CreateAsync_ShouldAddFragrance()
        {
            var context = TestDbContextFactory.Create();
            SeedBrandCategory(context);

            var service = CreateService(context);

            await service.CreateAsync(new FragranceFormModel
            {
                Name = "Test",
                Price = 10,
                ImageUrl = "x",
                Description = "x",
                BrandId = 1,
                CategoryId = 1,
                Gender = "M"
            });

            Assert.Single(context.Fragrances);
        }

        [Fact]
        public async Task DeleteAsync_ShouldRemoveFragrance()
        {
            var context = TestDbContextFactory.Create();
            SeedBrandCategory(context);

            context.Fragrances.Add(new Fragrance
            {
                Id = 1,
                Name = "F",
                Price = 10,
                ImageUrl = "x",
                Description = "x",
                Gender = "M",
                BrandId = 1,
                CategoryId = 1
            });

            context.SaveChanges();

            var service = CreateService(context);

            await service.DeleteAsync(1);

            Assert.Empty(context.Fragrances);
        }

        [Fact]
        public async Task Filter_ShouldFilterBySearch()
        {
            var context = TestDbContextFactory.Create();
            SeedBrandCategory(context);

            context.Fragrances.AddRange(
                new Fragrance { Name = "Aqua", Price = 10, ImageUrl = "x", Description = "x", Gender = "M", BrandId = 1, CategoryId = 1 },
                new Fragrance { Name = "Fire", Price = 10, ImageUrl = "x", Description = "x", Gender = "M", BrandId = 1, CategoryId = 1 }
            );

            context.SaveChanges();

            var service = CreateService(context);

            var result = await service.FragranceFilterAsync("Aqua", null, null, null, null, 1);

            Assert.Single(result.Fragrances);
        }

        [Fact]
        public async Task Filter_ShouldSortByPriceAscending()
        {
            var context = TestDbContextFactory.Create();
            SeedBrandCategory(context);

            context.Fragrances.AddRange(
                new Fragrance { Name = "A", Price = 20, ImageUrl = "x", Description = "x", Gender = "M", BrandId = 1, CategoryId = 1 },
                new Fragrance { Name = "B", Price = 10, ImageUrl = "x", Description = "x", Gender = "M", BrandId = 1, CategoryId = 1 }
            );

            context.SaveChanges();

            var service = CreateService(context);

            var result = await service.FragranceFilterAsync(null, null, null, null, "price_asc", 1);

            Assert.Equal(10, result.Fragrances.First().Price);
        }

        [Fact]
        public async Task Filter_ShouldPaginate()
        {
            var context = TestDbContextFactory.Create();
            SeedBrandCategory(context);

            for (int i = 0; i < 20; i++)
            {
                context.Fragrances.Add(new Fragrance
                {
                    Name = "Test" + i,
                    Price = 10,
                    ImageUrl = "x",
                    Description = "x",
                    Gender = "M",
                    BrandId = 1,
                    CategoryId = 1
                });
            }

            context.SaveChanges();

            var service = CreateService(context);

            var result = await service.FragranceFilterAsync(null, null, null, null, null, 2);

            Assert.Equal(8, result.Fragrances.Count());
        }
    }
}
