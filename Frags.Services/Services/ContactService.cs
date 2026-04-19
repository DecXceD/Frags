using Frags.Data.Data;
using Frags.Services.Interfaces;
using Frags.Services.ViewModels.Contact;
using Microsoft.EntityFrameworkCore;

namespace Frags.Services.Services
{
    public class ContactService : IContactService
    {
        private readonly FragsDbContext context;

        public ContactService(FragsDbContext context)
        {
            this.context = context;
        }

        public async Task<ContactViewModel?> GetAsync()
            => await context.Contacts
                .Select(c => new ContactViewModel
                {
                    Id = c.Id,
                    Email = c.Email,
                    Phone = c.Phone
                })
                .FirstOrDefaultAsync();

        public async Task UpdateAsync(ContactFormModel model)
        {
            var contact = await context.Contacts.FirstOrDefaultAsync();

            if (contact == null)
                return;

            contact.Email = model.Email;
            contact.Phone = model.Phone;

            await context.SaveChangesAsync();
        }
    }
}
