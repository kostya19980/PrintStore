using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace PrintStore.ViewModel
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Номер телефона не указан!")]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Некорректный номер телефона!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Пароль не указан!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class RegisterModel
    {
        [Required(ErrorMessage = "Номер телефона не указан!")]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Некорректный номер телефона!")]
        [Remote(action: "CheckPhone", controller: "Account", ErrorMessage = "Номер телефона уже используется!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Вы не указали Email!")]
        [EmailAddress(ErrorMessage = "Некорректный адрес!")]
        [Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Электронный адрес уже используется!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Вы не указали пароль!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Вы не указали пароль!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно!")]
        public string ConfirmPassword { get; set; }
    }
}
