using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrintStore.Models;
using PrintStore.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PrintStore.Controllers
{
    public class AdminController : Controller
    {
        PrintContext db;
        private IHostingEnvironment _env;
        public AdminController(PrintContext context, IHostingEnvironment env)
        {
            db = context;
            _env = env;
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SearchOrders(int? UserId)
        {
            List<Order> orders = new List<Order>();
            if (UserId != null)
            {
                orders = await db.Order.Include(a => a.Address).Include(u => u.User).Where(x => x.UserId == UserId).ToListAsync();
            }
            else
            {
                orders = await db.Order.Include(a => a.Address).Include(u => u.User).ToListAsync();
            }
            OrderSearchView model = new OrderSearchView
            {
                Orders = orders,
                filters=new OrderFilters
                {
                    SelectFilter="0"
                }
            };
            return View("~/Views/Admin/OrderManagement/OrderManagement.cshtml",model);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> SearchOrders(OrderSearchView model)
        {
            IQueryable<Order> orders = db.Order.Include(a => a.Address).Include(u => u.User);
            if (model.filters.OrderId != 0 && model.filters.OrderId!=null)
            {
                orders = orders.Where(x => x.OrderId == model.filters.OrderId);
            }
            if (model.filters.Phone != null)
            {
                orders = orders.Where(x => x.User.Login == model.filters.Phone);
            }
            if (model.filters.Email != null)
            {
                orders = orders.Where(x => x.User.Email == model.filters.Email);
            }
            if (model.filters.Date != null)
            {
                orders = orders.Where(x => x.OrderDate.ToShortDateString() == model.filters.Date);
            }
            if (model.filters.Status != 0)
            {
                orders = orders.Where(x => x.Status == model.filters.Status);
            }
            if (model.filters.Delivery != "0")
            {
                orders = orders.Where(x => x.Delivery == model.filters.Delivery);
            }
            model.Orders = await orders.ToListAsync();
            return View("~/Views/Admin/OrderManagement/OrderManagement.cshtml", model);
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserInfo(int UserId)
        {
            User user = await db.User.Include(p => p.Profile).FirstOrDefaultAsync(x => x.Id == UserId);
            int OrderCount = db.Order.Where(u => u.UserId == UserId).Count();
            ViewData["UserOrdersCount"] = OrderCount;
            return PartialView("~/Views/Admin/OrderManagement/_OrderOwnerInfo.cshtml", user);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task ChangeOrderStatus(int Status, int OrderId)
        {
            Order order = await db.Order.FirstOrDefaultAsync(x => x.OrderId == OrderId);
            order.Status = Status;
            db.Order.Update(order);
            await db.SaveChangesAsync();
        }
        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddProduct()
        {
            List<Category> categories = await db.Category.ToListAsync();
            CreateProduct model = new CreateProduct
            {
                Categories = new SelectList(categories, "Id", "Name")
            };
            return PartialView("~/Views/Products/_AddProduct.cshtml", model);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddProduct(CreateProduct model)
        {
            string ImageUrl = "";
            if (model.ProductImage != null)
            {
                string path = Path.Combine(_env.WebRootPath, "images","ProductImages");
                if (!System.IO.File.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path = Path.Combine(path,model.ProductImage.FileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await model.ProductImage.CopyToAsync(fileStream);
                }
                ImageUrl = Path.Combine("/images/ProductImages/", model.ProductImage.FileName);
            }
            product product = new product
            {
                Name = model.Name,
                Type = model.Type,
                Width = model.Width,
                Height = model.Height,
                Price = model.Price,
                CategoryId = model.CategoryId,
                PicturePath = ImageUrl
            };
            await db.product.AddAsync(product);
            await db.SaveChangesAsync();
            return RedirectToAction("CreateEmptyTemplate", "Editor", product);
        }
    }
}