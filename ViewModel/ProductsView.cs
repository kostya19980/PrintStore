using Microsoft.AspNetCore.Mvc;
using PrintStore.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace PrintStore.ViewModel
{
    public class ProductsView
    {
        public string CategoryName { get; set; }
        public List<product> Products { get; set; }
    }
}
