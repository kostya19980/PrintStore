using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace PrintStore.ViewModel
{
    public class UserProfileViewModel
    {
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$", ErrorMessage = "Некорректный номер телефона!")]
        [Remote(action: "CheckPhone", controller: "Account", ErrorMessage = "Номер телефона уже используется!")]
        public string Login { get; set; }
        [EmailAddress(ErrorMessage = "Некорректный адрес!")]
        [Remote(action: "CheckEmail", controller: "Account", ErrorMessage = "Электронный адрес уже используется!")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public string Flat { get; set; }
        [DataType(DataType.PostalCode,ErrorMessage = "Некорректный почтовый индекс!")]
        public string PostalCode { get; set; }
    }
}
