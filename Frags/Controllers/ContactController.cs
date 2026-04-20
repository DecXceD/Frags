using Frags.Services.Interfaces;
using Frags.Services.ViewModels.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Frags.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService service;

        public ContactController(IContactService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var contact = await service.GetAsync();

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit()
        {
            var contact = await service.GetAsync();

            if (contact == null)
                return NotFound();

            var model = new ContactFormModel
            {
                Id = contact.Id,
                Email = contact.Email,
                Phone = contact.Phone
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ContactFormModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await service.UpdateAsync(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
