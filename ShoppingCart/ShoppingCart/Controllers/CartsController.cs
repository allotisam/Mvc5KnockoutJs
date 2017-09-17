using AutoMapper;
using ShoppingCart.Models;
using ShoppingCart.Services;
using ShoppingCart.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCart.Controllers
{
    public class CartsController : Controller
    {
        private readonly CartService cartService = new CartService();

        public CartsController()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Cart, CartViewModel>();
                config.CreateMap<CartItem, CartItemViewModel>();
                config.CreateMap<Book, BookViewModel>();
                config.CreateMap<Author, AuthorViewModel>();
                config.CreateMap<Category, CategoryViewModel>();
            });
        }
        
        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            var cart = cartService.GetBySessionId(HttpContext.Session.SessionID);

            return PartialView(AutoMapper.Mapper.Map<Cart, CartViewModel>(cart));
        }
    }
}