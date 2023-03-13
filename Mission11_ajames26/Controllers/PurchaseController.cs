using Microsoft.AspNetCore.Mvc;
using Mission11_ajames26.Models;

namespace Mission11_ajames26.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
    }
}
