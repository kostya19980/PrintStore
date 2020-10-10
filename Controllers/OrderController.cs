using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PrintStore.Controllers
{
    public class OrderController : Controller
    {
        private PrintContext db;
        public OrderController(PrintContext context)
        {
            db = context;
        }
        [HttpGet]
        public async Task<IActionResult> OrderConfirm()
        {
            OrderConfirm model = new OrderConfirm();
            if (User.Identity.IsAuthenticated)
            {
                string UserName = db.GetUserName(HttpContext);
                User user = await db.User.Include(p=>p.Profile).ThenInclude(a=>a.Address).FirstOrDefaultAsync(x => x.Login == UserName);
                if (user.Profile == null)
                {
                    user.Profile = new UserProfile
                    {
                        Address = new Address()
                    };
                    db.User.Update(user);
                    await db.SaveChangesAsync();
                }
                else
                {
                    model = new OrderConfirm
                    {
                        Login = user.Login,
                        Email = user.Email,
                        FirstName = user.Profile.FirstName,
                        SecondName = user.Profile.SecondName,
                        City = user.Profile.Address.City,
                        Street = user.Profile.Address.Street,
                        Building = user.Profile.Address.Building,
                        Flat = user.Profile.Address.Flat,
                        PostalCode = user.Profile.Address.PostalCode
                    };
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> OrderConfirm(OrderConfirm model)
        {
            User user = await SaveUserInfo(model);
            decimal Total = 0;
            string ShoppingCartId = db.GetUserName(HttpContext);
            var ShoppingCart = db.Cart.Where(c => c.CartId == ShoppingCartId);
            Order order = new Order
            {
              User=user,
              Delivery=model.Delivery,
              OrderDate = DateTime.Now,
              Address=user.Profile.Address,
              OrderDetails=new List<OrderDetail>(),
              Status=1,
            };
            foreach (var item in ShoppingCart)
            {
                var orderDetail = new OrderDetail
                {
                    PaperId=item.PaperId,
                    TemplateId=item.TemplateId,
                    Quantity=item.Quantity,
                    Price=item.Price
                };
                Total += item.Price;
                order.OrderDetails.Add(orderDetail);
                db.Cart.Remove(item);
            }
            order.Total = Total;
            await db.Order.AddAsync(order);
            await db.SaveChangesAsync();
            return RedirectToAction("Complete", "Order", new { id=order.OrderId});
        }
        public async Task<User> SaveUserInfo(OrderConfirm model)
        {
            Address address = await db.Address.FirstOrDefaultAsync(x => x.City == model.City && x.Street == model.Street &&
            x.Building == model.Building && x.Flat == model.Flat && x.PostalCode == model.PostalCode);
            if (address == null)
            {
                address = new Address
                {
                    City = model.City,
                    Street = model.Street,
                    Building = model.Building,
                    Flat = model.Flat,
                    PostalCode = model.PostalCode
                };
            }
            User user = new User();
            if (User.Identity.IsAuthenticated)
            {
                string UserName = db.GetUserName(HttpContext);
                user = await db.User.Include(p => p.Profile).FirstOrDefaultAsync(x => x.Login == UserName);
                user.Profile.Address = address;
                if (user.Profile.FirstName != model.FirstName || user.Profile.SecondName != model.SecondName)
                {
                    user.Profile.FirstName = model.FirstName;
                    user.Profile.SecondName = model.SecondName;
                }
                db.User.Update(user);
            }
            else
            {
                UserProfile profile = new UserProfile
                {
                    FirstName = model.FirstName,
                    SecondName = model.SecondName,
                    Address=address
                };
                Role anonimRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "anonim");
                user = new User
                {
                    Login = model.Login,
                    Email = model.Email,
                    Role= anonimRole,
                    Password = Guid.NewGuid().ToString(),
                    Profile = profile
                };
                await db.User.AddAsync(user);
            }
            await db.SaveChangesAsync();
            return user;
        }
        public ActionResult Complete(int id)
        {
            ViewData["OrderId"] = id;
            return View();
        }
    }
}
