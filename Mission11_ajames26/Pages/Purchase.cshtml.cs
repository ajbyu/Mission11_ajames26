using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission11_ajames26.Infrastructure;
using Mission11_ajames26.Models;
using Mission11_ajames26.Repositories;
using System.Linq;

namespace Mission11_ajames26.Pages
{
    public class PurchaseModel : PageModel
    {
        public PurchaseModel(IBookRepository bookRepository, Cart cart)
        {
            _repo = bookRepository;
            this.cart = cart;
        }

        //Repository and cart object
        private IBookRepository _repo;
        public Cart cart { get; set; }

        public string ReturnUrl { get; set; }

        //GET and POST methods
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book book = _repo.Books.FirstOrDefault(b => b.BookId == bookId);

            cart.AddCartItem(book, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.CartItems.First(i => i.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
