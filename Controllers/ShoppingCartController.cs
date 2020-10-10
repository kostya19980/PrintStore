using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrintStore.Models;
using PrintStore.ViewModel;
namespace PrintStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        PrintContext db;
        public ShoppingCartController(PrintContext context)
        {
            db = context;
        }

        public ActionResult CartView()
        {
            string ShoppingCartId = db.GetUserName(HttpContext);
            var ShoppingCart = db.Cart.Include(paper => paper.Paper).
                Include(t => t.Template).ThenInclude(p => p.Product).ThenInclude(c => c.Category).
                Where(c => c.CartId == ShoppingCartId).ToList();
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = ShoppingCart,
                TotalPrice= GetTotal()
            };
            return View(viewModel);
        }
        public async Task<IActionResult> AddToCart(int TemplateId)
        {
            Template UserTemplate = await db.Template.Include(p=>p.Product).Include(u => u.User).FirstOrDefaultAsync(t => t.Id == TemplateId);
            if (UserTemplate != null)
            {
                string ShoppingCartId = db.GetUserName(HttpContext);
                if ((UserTemplate.User != null && UserTemplate.User.Login == ShoppingCartId) || UserTemplate.Name == ShoppingCartId)
                {
                    Cart item = await db.Cart.FirstOrDefaultAsync(t => t.TemplateId == TemplateId && t.CartId == ShoppingCartId);
                    if (item == null)
                    {
                        Cart cartItem = new Cart
                        {
                            CartId = ShoppingCartId,
                            Template = UserTemplate,
                            Quantity = 10,
                            DateCreated = DateTime.Now,
                        };
                        if (UserTemplate.Product.CategoryId == 9)
                        {
                            cartItem.Price = UserTemplate.Product.Price * 10;
                        }
                        else
                        {
                            cartItem.Price = 240.00M;
                            cartItem.PaperId = 11;
                        }
                        await db.Cart.AddAsync(cartItem);
                        await db.SaveChangesAsync();
                    }
                }
            }
            return RedirectToAction("CartView","ShoppingCart");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int DeleteId)
        {
            string ShoppingCartId = db.GetUserName(HttpContext);
            Cart item = await db.Cart.Include(t => t.Template).FirstOrDefaultAsync(c => c.CartId== ShoppingCartId && c.RecordId==DeleteId);
            if (item != null)
            {
                db.Cart.Remove(item);
                if (!User.Identity.IsAuthenticated)
                {
                    db.Template.Remove(item.Template);
                }
            }
            await db.SaveChangesAsync();
            return Json(new {Total = GetTotal().ToString(),Quantity=GetCartQuantity() });
        }
        [HttpPost]
        [Produces("application/json")]
        public async Task<IActionResult> CalculateCost([FromBody] CartOptionsSerializer data)
        {
            decimal ItemPrice = 0;
            string ShoppingCartId = db.GetUserName(HttpContext);
            Cart item = await db.Cart.Include(t => t.Template).ThenInclude(p => p.Product).FirstOrDefaultAsync(c => c.CartId == ShoppingCartId && c.RecordId == data.ItemId);
            if (item.Template.Product.CategoryId != 9)
            {
                Paper paper = await db.Paper.FirstOrDefaultAsync(x => x.PrintType == data.PrintType && x.PaperType == data.PaperType && x.PaperDensity == data.PaperDensity);
                PrintPrice printPrice = await db.PrintPrice.FirstOrDefaultAsync(x => x.PrintType == data.PrintType && x.Sides == item.Template.Product.Type && x.Quantity == data.Quantity);
                if (printPrice != null)
                {
                    ItemPrice = data.Quantity * (paper.Price + printPrice.Price);
                    item.Paper = paper;
                }
                else return Json("error");
            }
            else
            {
                ItemPrice = data.Quantity * item.Template.Product.Price;
            }
            item.Quantity = data.Quantity;
            item.Price = ItemPrice;
            db.Cart.Update(item);
            await db.SaveChangesAsync();
            decimal Total = GetTotal();
            return Json(new {Id=item.RecordId, ItemPrice=ItemPrice.ToString(), Total= Total.ToString() });
        }
        public decimal GetTotal()
        {
            decimal Total = 0;
            string ShoppingCartId = db.GetUserName(HttpContext);
            var ShoppingCart = db.Cart.Where(c => c.CartId == ShoppingCartId);
            foreach(var cart in ShoppingCart)
            {
                Total += cart.Price;
            }
            return Total;
        }
        public int GetCartQuantity()
        {
            string ShoppingCartId = db.GetUserName(HttpContext);
            int Quantity = db.Cart.Where(c => c.CartId == ShoppingCartId).Count();
            return Quantity;
        }


    }
}
