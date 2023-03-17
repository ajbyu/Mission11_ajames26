using Microsoft.AspNetCore.Mvc;
using Mission11_ajames26.Models;
using Mission11_ajames26.Repositories;

namespace Mission11_ajames26.Controllers
{
    public class PurchaseController : Controller
    {
        public PurchaseController(IPurchaseRepository repo, Cart cart)
        {
            _repo = repo;
            _cart = cart;
        }

        private IPurchaseRepository _repo { get; set; }
        private Cart _cart;

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (_cart.CartItems.Count == 0)
            {
                //Thanks for the quote, Marcus
                ModelState.AddModelError("", "Buy something!");
            }

            if (ModelState.IsValid)
            {
                purchase.Items = _cart.CartItems.ToArray();

                _repo.SavePurchase(purchase);

                _cart.EmptyCart();

                return RedirectToPage("/CheckoutConfirmation");
            }

            else
            {
                //Return to view and show errors if model is not valid
                return View();
            }
        }
    }
}
