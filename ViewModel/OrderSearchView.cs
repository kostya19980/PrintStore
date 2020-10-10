using Microsoft.AspNetCore.Mvc;
using PrintStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStore.ViewModel
{
    public class OrderSearchView
    {
        public List<Order> Orders { get; set; }
        public OrderFilters filters { get; set; }
    }
    public class OrderFilters
    {
        public int? Status { get; set; }
        public string Delivery { get; set; }
        public string Date { get; set; }
        public int? OrderId { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный адрес!")]
        public string Email { get; set; }
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Некорректный номер телефона!")]
        public string Phone { get; set; }
        public string SelectFilter { get; set; }
    }
}
