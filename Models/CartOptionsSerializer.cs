using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PrintStore.Models
{   
    public class CartOptionsSerializer
    {
        public int ItemId { get; set; }
        public string PrintType { get; set; }
        public string PaperType { get; set; }
        public int PaperDensity { get; set; }
        public int Quantity { get; set; }
    }
}
