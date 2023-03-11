using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Mission11_ajames26.Infrastructure;
using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Mission11_ajames26.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddCartItem(Book book, int quantity)
        {
            base.AddCartItem(book, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Cart", this);
        }

        public override void EmptyCart()
        {
            base.EmptyCart();
            Session.Remove("Cart");
        }
    }
}
