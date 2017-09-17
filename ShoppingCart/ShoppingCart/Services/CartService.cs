using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Services
{
    public class CartService : IDisposable
    {
        private ShoppingCartContext dbContext = new ShoppingCartContext();

        public Cart GetBySessionId(string sessionId)
        {
            var cart = dbContext.Carts.Include("CartItems").Where(c => c.SessionId == sessionId).SingleOrDefault();
            cart = CreateCartIfItDoesntExist(sessionId, cart);

            return cart;
        }

        private Cart CreateCartIfItDoesntExist(string sessionId, Cart cart)
        {
            if (cart == null)
            {
                cart = new Cart
                {
                    SessionId = sessionId,
                    CartItems = new List<CartItem>()
                };
                dbContext.Carts.Add(cart);
                dbContext.SaveChanges();
            }

            return cart;
        }

        public void Dispose()
        {
            dbContext.Dispose();

            this.Dispose();
        }
    }
}