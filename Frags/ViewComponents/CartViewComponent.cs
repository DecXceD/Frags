using Frags.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Frags.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartService cartService;

        public CartViewComponent(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sessionId = HttpContext.Session.Id;

            var count = await cartService.GetCartCountAsync(sessionId);

            return View(count);
        }
    }
}
