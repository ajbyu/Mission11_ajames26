using System.Collections.Generic;
using System.Linq;

namespace Mission11_ajames26.Models
{
    public class Cart
    {
        //Cart
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        //Add
        public virtual void AddCartItem(Book book, int quantity)
        {
            if (!CartItems.Any(i => i.Book.BookId == book.BookId))
            {
                CartItems.Add(new CartItem { Book = book, Quantity = quantity });
            }
            else
            {
                CartItems.Single(i => i.Book.BookId == book.BookId).Quantity += quantity;
            }
        }

        //Remove
        public virtual void RemoveItem(Book book)
        {
            CartItems.RemoveAll(b => b.Book.BookId == book.BookId);
        }

        //Clear basket
        public virtual void EmptyCart()
        {
            CartItems.Clear();
        }

        //Get cart total
        public double CalculateTotal()
        {
            double total = CartItems.Sum(i => i.Quantity * i.Book.Price);

            return total;
        }
    }

    public class CartItem
    {
        public int LineId { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
