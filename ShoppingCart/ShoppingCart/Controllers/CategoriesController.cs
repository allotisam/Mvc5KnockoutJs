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
    public class CategoriesController : Controller
    {
        private readonly CategoryService categoryService = new CategoryService();
        
        public CategoriesController()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Category, CategoryViewModel>();
            });
        }

        [ChildActionOnly]
        public PartialViewResult Menu(int selectedCategoryId)
        {
            ViewBag.SelectedCategoryId = selectedCategoryId;

            var categories = categoryService.Get();
            return PartialView(AutoMapper.Mapper.Map<List<Category>, List<CategoryViewModel>>(categories));
        }
    }
}