using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Description = "Description for product 1",
                Name = "Product 1",
                Quantity = 15
            },
            new Product
            {
                Id = 2,
                Description = "Description for product 2",
                Name = "Product 2",
                Quantity = 25
            },
            new Product
            {
                Id = 3,
                Description = "Description for product 3",
                Name = "Product 3",
                Quantity = 35
            }
        };
        public ActionResult List()
        {
            ViewBag.Products = _products;
            return View();
        }

        public ActionResult Details(int id)
        {
            ViewBag.Product = _products.First(x => x.Id == id);
            return View();
        }
    }
}