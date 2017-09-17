using ShoppingCart.DAL;
using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Services
{
    public class CategoryService : IDisposable
    {
        private ShoppingCartContext dbContext = new ShoppingCartContext();

        public List<Category> Get()
        {
            return dbContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public void Dispose()
        {
            dbContext.Dispose();

            this.Dispose();
        }
    }
}