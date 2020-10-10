using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using PrintStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PrintStore.ViewModel
{
    public class CreateProduct
    {
        [Required(ErrorMessage = "Название не указано!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Тип не указан!")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Ширина не указана!")]
        public string Width { get; set; }
        [Required(ErrorMessage = "Высота не указана!")]
        public string Height { get; set; }
        [Required(ErrorMessage = "Стоимоть не указана!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Изображение не выбрано!")]
        public IFormFile ProductImage { get; set; }
        [Required(ErrorMessage = "Категория не выбрана!")]
        public int CategoryId { get; set; }
        public SelectList Categories { get; set; }
    }
}
