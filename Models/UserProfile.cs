using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace PrintStore.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Flat { get; set; }
        public string PostalCode { get; set; }
        public List<UserProfile> UserProfile { get; set; }
        public List<Order> Orders { get; set; }
    }
}
