using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrintStore.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using PrintStore.ViewModel;

namespace PrintStore.Controllers
{
    public class UserProfileController : Controller
    {
        private PrintContext db;
        public UserProfileController(PrintContext context)
        {
            db = context;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
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
            UserProfile profile=user.Profile;
            UserProfileViewModel model = new UserProfileViewModel
            {
               Login=user.Login,
               Email=user.Email,
               FirstName=profile.FirstName,
               SecondName=profile.SecondName,
               City=profile.Address.City,
               Street=profile.Address.Street,
               Building= profile.Address.Building,
               Flat=profile.Address.Flat,
               PostalCode=profile.Address.PostalCode               
            };
            return View(model);
        }
        //[HttpGet]
        //[Authorize]
        //public async Task<IActionResult> UserOrders(int? UserId)
        //{
        //    string UserName = db.GetUserName(HttpContext);
        //    List<Order> orders = await db.Order.Include(a => a.Address).Where(x => x.User.Login == UserName).ToListAsync();
        //    return View(orders);
        //}
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOrderDetails(int OrderId)
        {
            string UserName = db.GetUserName(HttpContext);
            List<OrderDetail> orderDetails = await db.OrderDetails.Include(p=>p.Paper)
                .Include(t=>t.Template).ThenInclude(pr=>pr.Product).ThenInclude(c=>c.Category)
                .Where(x => x.OrderId==OrderId && (x.Order.User.Login == UserName || User.IsInRole("admin"))).ToListAsync();
            return PartialView("~/Views/UserProfile/_OrderDetail.cshtml", orderDetails);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(UserProfileViewModel model)
        {
            string UserName = db.GetUserName(HttpContext);
            User user = await db.User.Include(p => p.Profile).ThenInclude(a=>a.Address).FirstOrDefaultAsync(x => x.Login == UserName);
            Address address = await db.Address.FirstOrDefaultAsync(x => x.City == model.City && x.Street== model.Street && 
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
            user.Profile.Address = address;
            if(user.Profile.FirstName!=model.FirstName || user.Profile.SecondName != model.SecondName)
            {
                user.Profile.FirstName = model.FirstName;
                user.Profile.SecondName = model.SecondName;
            }
            if(user.Login!=model.Login || user.Email != model.Email)
            {
                user.Login = model.Login;
                user.Email = model.Email;
            }
            db.User.Update(user);
            await db.SaveChangesAsync();
            return View(model);
        }
    }
}
