using System.ComponentModel.DataAnnotations;

namespace ToDoList.PL.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="First Name is Required")]
        public string Fname { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string Lname { get; set; }
        [Required(ErrorMessage ="Email Address is Requried")]
        [EmailAddress(ErrorMessage ="Email is Invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is requried")]
        [DataType(DataType.Password , ErrorMessage ="Password is requried")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password is requried")]
        [DataType(DataType.Password, ErrorMessage = "Password is requried")]
        [Compare("Password" ,ErrorMessage ="Password didn't Match")]
        public string ConfirmPassword { get; set; }

        public bool IsAgree { get; set; }
    }
}
