using Frags.Services.ViewModels.Contact;

namespace Frags.Services.Interfaces
{
    public interface IContactService
    {
        Task<ContactViewModel?> GetAsync();
        Task UpdateAsync(ContactFormModel model);
    }
}
