using Frags.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Frags.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var items = await cartService.GetUserCartAsync(userId!);

            return View(items);
        }

        public async Task<IActionResult> Add(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await cartService.AddToCartAsync(id, userId!);

            return RedirectToAction("Index", "Shop");
        }

        public async Task<IActionResult> Remove(int id)
        {
            await cartService.RemoveAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
