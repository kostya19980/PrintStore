using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PrintStore.Models
{   
    public class PrintPrice
    {
        [Key]
        public int Id { get; set; }
        public string PrintType { get; set; }
        public string Sides { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
