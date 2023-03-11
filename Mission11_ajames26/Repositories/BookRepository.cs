using System.Linq;
using Mission11_ajames26.Models;

namespace Mission11_ajames26.Repositories
{
    public class BookRepository : IBookRepository
    {
        private BookstoreContext _context { get; set; }

        public BookRepository(BookstoreContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;

    }
}
