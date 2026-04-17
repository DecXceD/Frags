using Frags.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Frags.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        private string GetSessionId()
        {
            if (HttpContext.Session.GetString("Init") == null)
            {
                HttpContext.Session.SetString("Init", "1");
            }

            return HttpContext.Session.Id;
        }

        public async Task<IActionResult> Index()
        {
            var sessionId = GetSessionId();

            var items = await cartService.GetCartItemsAsync(sessionId);
            var total = await cartService.GetTotalAsync(sessionId);

            ViewBag.Total = total;

            return View(items);
        }

        public async Task<IActionResult> Add(int id)
        {
            var sessionId = GetSessionId();

            await cartService.AddToCartAsync(id, sessionId);

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public async Task<IActionResult> Remove(int id)
        {
            await cartService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
