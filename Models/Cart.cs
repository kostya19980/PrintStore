using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PrintStore.Models
{   
    public class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int? PaperId { get; set; }
        public Paper Paper { get; set; }
        public int TemplateId { get; set; }
        public Template Template { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
