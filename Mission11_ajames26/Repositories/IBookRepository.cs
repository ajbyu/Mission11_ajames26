using System.Linq;
using Mission11_ajames26.Models;

namespace Mission11_ajames26.Repositories
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
