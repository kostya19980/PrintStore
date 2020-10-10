using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrintStore.Models;
using PrintStore.ViewModel;

namespace PrintStore.Controllers
{
    public class ProductsController : Controller
    {
        PrintContext db;
        public ProductsController(PrintContext context)
        {
            db = context;
        }
        //[Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Products(int CategoryId, string Type, string Size, List<Color> Color, List<Subcategory> Subcategory, List<Style> Style)
        {
            List<product> products = await db.product.Where(x=>x.CategoryId==CategoryId).ToListAsync();
            Category category  = await db.Category.FirstOrDefaultAsync(n => n.Id == CategoryId);
            ProductsView model = new ProductsView
            {
                Products=products,
                CategoryName=category.Name
            };
            //if (Type!=null)
            //{
            //    products = products.Where(x => x.Type == Type);
            //}
            //if (Size != null)
            //{
            //    products = products.Where(x => x.Size == Size);
            //}
            //if (Color != null)
            //{
            //    products = products.Where(x => x.ProductColors.);
            //}
            //if (Subcategory != null)
            //{
            //    products = products.Where(x => x.Subcategories == Subcategory);
            //}
            //if (Style != null)
            //{
            //    products = products.Where(x => x.Styles == Style);
            //}
            return View(model);
        }
        public IActionResult About()
        {
            
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
