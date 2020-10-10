using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PrintStore.ViewModel
{
    public class OrderConfirm
    {
        [Required(ErrorMessage = "Имя не указано!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Фамилия не указана!")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Номер телефона не указан!")]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Некорректный номер телефона!")]
        [Remote(action: "CheckPhone", controller: "Account", ErrorMessage = "Номер телефона уже используется!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Вы не указали Email!")]
        [EmailAddress(ErrorMessage = "Некорректный адрес!")]
        [Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Электронный адрес уже используется!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Вы не указали город!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Вы не выбрали способ получения!")]
        public string Delivery { get; set; }
        [Required(ErrorMessage = "Вы не указали улицу!")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Вы не указали дом!")]
        public string Building { get; set; }
        public string Flat { get; set; }
        [DataType(DataType.PostalCode, ErrorMessage = "Некорректный почтовый индекс!")]
        public string PostalCode { get; set; }
    }
}
