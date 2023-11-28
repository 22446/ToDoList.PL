using System.ComponentModel.DataAnnotations;

namespace ToDoList.PL.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password is requried")]
        [DataType(DataType.Password, ErrorMessage = "Password is requried")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password is requried")]
        [DataType(DataType.Password, ErrorMessage = "Password is requried")]
        [Compare("Password", ErrorMessage = "Password didn't Match")]
        public string ConfirmPassword { get; set; }
    }
}
