using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
namespace PrintStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public UserProfile Profile { get; set; }
        public List<Template> Templates { get; set; }
        public List<Order> Orders { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
