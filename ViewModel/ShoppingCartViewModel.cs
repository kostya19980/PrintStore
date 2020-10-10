using PrintStore.Models;
using System.Collections.Generic;
namespace PrintStore.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
