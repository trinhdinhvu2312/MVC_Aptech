using Microsoft.AspNetCore.Mvc;
using MVC_Aptech.Models;
using System.Collections.Generic;

namespace MVC_Aptech.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.productA = new Product
            {
                Id = 1,
                Name = "Iphone 12 Promax",
                Price = 20000.0f,
                Count = 2,
                Description = "Made in China"
            };

            List<Product> products = new List<Product>
    {
        new Product
        {
            Id = 1,
            Name = "Iphone 12 Promax",
            Price = 20000.0f,
            Count = 2,
            Description = "Made in China"
        },
        new Product
        {
            Id = 2,
            Name = "Iphone 13 Promax",
            Price = 30000.0f,
            Count = 4,
            Description = "Made in China"
        },
        new Product
        {
            Id = 3,
            Name = "Iphone 14 Promax",
            Price = 40000.0f,
            Count = 1,
            Description = "Made in China"
        }
    };

            ViewBag.products = products;

            return View();
        }

        // https://localhost:port/Product/DoSomething
        public IActionResult DoSomething(Product model)
        {
            if (ModelState.IsValid)
            {
                // Xử lý dữ liệu khi validation thành công

                return RedirectToAction("Index");
            }

            // Nếu validation không thành công, quay trở lại view với Model và hiển thị thông báo lỗi
            return View(model);
        }
    }
}
