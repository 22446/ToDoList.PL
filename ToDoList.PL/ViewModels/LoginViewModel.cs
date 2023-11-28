using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.PL.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email Address is Requried")]
        [EmailAddress(ErrorMessage = "Email is Invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is requried")]
        [DataType(DataType.Password, ErrorMessage = "Password is requried")]
        public string Password { get; set; }
        public bool IsAgree { get; set; }
    }
}
