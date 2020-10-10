using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStore.Models
{
    public class Template
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JsonTemplate { get; set; }
        public User User { get; set; }
        public product Product { get; set; }
        public Cart Cart { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public int? ProductId { get; set; }
        public int? UserId { get; set; }
        public string DateCreated { get; set; }
    }
}
