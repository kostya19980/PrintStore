using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PrintStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public string Delivery { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public int Status { get; set; }
    }
}
