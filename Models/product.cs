using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrintStore.Models
{
    public class product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public decimal Price { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<ProductSubcategory> ProductSubcategories { get; set; }
        public List<ProductStyle> ProductStyles { get; set; }
        public List<Template> Templates { get; set; }
        public int? TemplateId { get; set; }
        public string PicturePath { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public product()
        {
            ProductColors = new List<ProductColor>();
            ProductSubcategories = new List<ProductSubcategory>();
            ProductStyles = new List<ProductStyle>();
        }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<product> Products { get; set; }
    }
    public class Color
    {
        public int Id { get; set; }
        public string ColorString { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public Color()
        {
            ProductColors = new List<ProductColor>();
        }

    }
    public class ProductColor
    {
        public int ProductId { get; set; }
        public product Product { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }
    }
    public class Subcategory
    {
        public int Id { get; set; }
        public string SubcategoryName { get; set; }
        public List<ProductSubcategory> ProductSubcategories { get; set; }
        public Subcategory()
        {
            ProductSubcategories = new List<ProductSubcategory>();
        }
    }
    public class ProductSubcategory
    {
        public int ProductId { get; set; }
        public product Product { get; set; }

        public int SubcategoryId { get; set; }
        public Subcategory Subcategory { get; set; }
    }
    public class Style
    {
        public int Id { get; set; }
        public string StyleName { get; set; }
        public List<ProductStyle> ProductStyles { get; set; }
        public Style()
        {
            ProductStyles = new List<ProductStyle>();
        }
    }
    public class ProductStyle
    {
        public int ProductId { get; set; }
        public product Product { get; set; }

        public int StyleId { get; set; }
        public Style Style { get; set; }
    }
}
