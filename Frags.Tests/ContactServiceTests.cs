using Frags.Data.Models;
using Frags.Services.Services;
using Frags.Services.ViewModels.Contact;

namespace Frags.Tests
{
    public class ContactServiceTests
    {
        [Fact]
        public async Task GetAsync_ShouldReturnContact()
        {
            var context = TestDbContextFactory.Create();

            context.Contacts.Add(new Contact
            {
                Email = "test@test.com",
                Phone = "123"
            });

            context.SaveChanges();

            var service = new ContactService(context);

            var result = await service.GetAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task UpdateAsync_ShouldUpdateContact()
        {
            var context = TestDbContextFactory.Create();

            context.Contacts.Add(new Contact
            {
                Id = 1,
                Email = "old",
                Phone = "1"
            });

            context.SaveChanges();

            var service = new ContactService(context);

            await service.UpdateAsync(new ContactFormModel
            {
                Email = "new",
                Phone = "2"
            });

            var contact = context.Contacts.First();

            Assert.Equal("new", contact.Email);
        }
    }
}
