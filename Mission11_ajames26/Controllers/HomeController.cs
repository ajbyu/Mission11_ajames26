using Microsoft.AspNetCore.Mvc;
using Mission11_ajames26.Models.ViewModels;
using Mission11_ajames26.Repositories;
using System.Linq;

namespace Mission11_ajames26.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _bookRepo { get; }

        public HomeController(IBookRepository bookRepository)
        {
            _bookRepo = bookRepository;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            BooksViewModel vm = new BooksViewModel()
            {
                //Loads books and determine page
                Books = _bookRepo
                    .Books
                    .Where(b => b.Category == bookCategory || bookCategory == null)
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(10),

                //Determine page size
                PageInfo = new PageInfo
                {
                    NumBooks = 
                        (bookCategory == null
                            ? _bookRepo.Books.Count()
                            : _bookRepo.Books.Where(b => b.Category == bookCategory).Count()),
                    PageSize = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(vm);
        }
    }
}
