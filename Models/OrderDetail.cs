using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PrintStore.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int? PaperId { get; set; }
        public Paper Paper { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
