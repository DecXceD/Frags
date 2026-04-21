using Frags.Data.Models;
using Frags.Services.Services;

namespace Frags.Tests
{
    public class CartServiceTests
    {
        [Fact]
        public async Task AddToCart_ShouldCreateItem()
        {
            var context = TestDbContextFactory.Create();

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

            var service = new CartService(context);

            await service.AddToCartAsync(1, "session");

            Assert.Single(context.CartItems);
        }

        [Fact]
        public async Task AddToCart_ShouldIncreaseQuantity_WhenExists()
        {
            var context = TestDbContextFactory.Create();

            context.CartItems.Add(new CartItem
            {
                FragranceId = 1,
                Quantity = 1,
                SessionId = "session"
            });

            context.SaveChanges();

            var service = new CartService(context);

            await service.AddToCartAsync(1, "session");

            Assert.Equal(2, context.CartItems.First().Quantity);
        }

        [Fact]
        public async Task GetTotalAsync_ShouldCalculateCorrectly()
        {
            var context = TestDbContextFactory.Create();

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

            context.CartItems.Add(new CartItem
            {
                FragranceId = 1,
                Quantity = 2,
                SessionId = "session"
            });

            context.SaveChanges();

            var service = new CartService(context);

            var total = await service.GetTotalAsync("session");

            Assert.Equal(20, total);
        }

        [Fact]
        public async Task Increase_ShouldIncreaseQuantity()
        {
            var context = TestDbContextFactory.Create();

            context.CartItems.Add(new CartItem
            {
                Id = 1,
                Quantity = 1,
                SessionId = "session"
            });

            context.SaveChanges();

            var service = new CartService(context);

            await service.IncreaseAsync(1);

            Assert.Equal(2, context.CartItems.First().Quantity);
        }

        [Fact]
        public async Task Decrease_ShouldRemove_WhenZero()
        {
            var context = TestDbContextFactory.Create();

            context.CartItems.Add(new CartItem
            {
                Id = 1,
                Quantity = 1,
                SessionId = "session"
            });

            context.SaveChanges();

            var service = new CartService(context);

            await service.DecreaseAsync(1);

            Assert.Empty(context.CartItems);
        }
    }
}
