using System.ComponentModel.DataAnnotations;

namespace ToDoList.PL.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email Address is Requried")]
        [EmailAddress(ErrorMessage = "Email is Invalid")]
        public string Email { get; set; }
    }
}
