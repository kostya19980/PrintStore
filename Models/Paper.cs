using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PrintStore.Models
{   
    public class Paper
    {
        [Key]
        public int Id { get; set; }
        public string PrintType { get; set; }
        public string PaperType { get; set; }
        public int PaperDensity { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public List<Cart> Carts { get; set; }
    }
}
