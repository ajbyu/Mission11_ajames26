using Microsoft.AspNetCore.Mvc;
using Mission11_ajames26.Models;

namespace Mission11_ajames26.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            //Get session cart to return to component
            this.cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
