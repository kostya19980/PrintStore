using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace PrintStore.Models
{
   
    public class PrintContext : DbContext
    {
        public DbSet<product> product { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<Style> Style { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Template> Template { get; set; }
        public DbSet<Paper> Paper { get; set; }
        public DbSet<PrintPrice> PrintPrice { get; set; }
        public DbSet<Address> Address { get; set; }
        public PrintContext(DbContextOptions<PrintContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public string GetUserName(HttpContext context)
        {
            if (context.Session.GetString("UserName") == null)
            {
                if (context.User.Identity.IsAuthenticated)
                {
                    context.Session.SetString("UserName", context.User.Identity.Name);
                }
                else
                {
                    context.Session.SetString("UserName", Guid.NewGuid().ToString());
                }
            }
            return context.Session.GetString("UserName");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////////////////////////RELATION_SHIPS//////////////////////////////
            modelBuilder.Entity<ProductColor>()
                .HasKey(k => new { k.ProductId, k.ColorId });

            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductColor>()
                .HasOne(pc => pc.Color)
                .WithMany(p => p.ProductColors)
                .HasForeignKey(pc => pc.ColorId);
            ///////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<ProductStyle>()
                .HasKey(k => new { k.ProductId, k.StyleId });

            modelBuilder.Entity<ProductStyle>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductStyles)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductStyle>()
                .HasOne(ps => ps.Style)
                .WithMany(p => p.ProductStyles)
                .HasForeignKey(ps => ps.StyleId);
            ////////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<ProductSubcategory>()
                .HasKey(k => new { k.ProductId, k.SubcategoryId });

            modelBuilder.Entity<ProductSubcategory>()
                .HasOne(ps => ps.Product)
                .WithMany(p => p.ProductSubcategories)
                .HasForeignKey(ps => ps.ProductId);

            modelBuilder.Entity<ProductSubcategory>()
                .HasOne(ps => ps.Subcategory)
                .WithMany(p => p.ProductSubcategories)
                .HasForeignKey(ps => ps.SubcategoryId);
            ///////////////////////////////////////////////////////
            string adminLogin = "+7 (999) 920-75-00";
            string adminEmail = "fennix1990@yandex.ru";
            string adminPassword = "a13814069b";
            List<string> categories = new List<string> { "Буклет", "Визитка", "Листовка", "Плакат", "Календарь", "Блокнот", "Открытка", "Одежда", "Сувенирная продукция" };
            int i = 1;
            foreach(string cat in categories)
            {
                Category c = new Category { Id=i,Name = cat };
                modelBuilder.Entity<Category>().HasData(new Category[] { c });
                i++;
            }
            Role adminRole = new Role { Id = 1, Name = "admin" };
            Role userRole = new Role { Id = 2, Name = "user" };
            Role AnonimRole = new Role { Id = 3, Name = "anonim" };
            User adminUser = new User { Id = 1,Login=adminLogin, Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id};
            TemplateSerializer TestTemplateJson = new TemplateSerializer
            {
                Width = 494,
                Height = 294,
                Images = new List<TemplateImage>(),
                TextBlocks = new List<TemplateText>()
            };
            Template TestTemplate = new Template
            {
                Id = 1,
                Name="Test",
                ProductId = 1,
                UserId = 1,
                JsonTemplate = JsonSerializer.Serialize<TemplateSerializer>(TestTemplateJson),
                DateCreated = DateTime.Now.ToShortDateString()
            };
            TemplateSerializer TestTemplateJson2 = new TemplateSerializer
            {
                Width = 1559,
                Height = 583,
                Images = new List<TemplateImage>(),
                TextBlocks = new List<TemplateText>(),
                Texture=new TemplateTexture {
                    TextureName = "Cup_Texture2.png",
                    ModelName = "Cup.obj",
                    TextureSrc = "/3dModels/cup/",
                    ModelSrc= "/3dModels/cup/",
                    Width =2048,
                    Height=2048,
                    TextureAreas=new List<TextureArea>()
                }
            };
            TextureArea area = new TextureArea
            {
                Name = "OuterSide",
                Width = 583,
                Height = 1559,
                Top = 489,
                Left = 58
            };
            TestTemplateJson2.Texture.TextureAreas.Add(area);
            Template TestTemplate2 = new Template
            {
                Id = 2,
                Name = "Test_cup",
                ProductId = 2,
                UserId = 1,
                JsonTemplate = JsonSerializer.Serialize<TemplateSerializer>(TestTemplateJson2),
                DateCreated = DateTime.Now.ToShortDateString()
            };
            modelBuilder.Entity<Template>().HasData(new Template[] { TestTemplate, TestTemplate2 });
            product product = new product {Id=1, CategoryId = 2, Name = "Компания", PicturePath = "/images/test_product.png", Height = "5", Width="9", Type = "Двусторонняя", TemplateId=1, Price=240};
            product cupProduct = new product { Id = 2, CategoryId = 9, Name = "Кружка1", PicturePath = "/images/cup_product_image.jpg", Height="9", Width="8,1", Type = "Кружка", TemplateId = 2, Price=100 };
            modelBuilder.Entity<product>().HasData(new product[] { product, cupProduct });
            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole,AnonimRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}
