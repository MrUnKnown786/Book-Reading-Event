using Book.Reading.Event.Base;
using System.ComponentModel.DataAnnotations;

namespace Book.Reading.Event.Core.Entities
{
    public class SignUp
    {
        [Required(ErrorMessage = "Please Enter your User Name")]
        [Display(Name = "User Name")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please Enter your Email Address")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Please provide a valid Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter Password")]
        [Display(Name = "Password")]
        [Compare("confirmpassword", ErrorMessage = "Password does not match")]
        [DataType(DataType.Password, ErrorMessage = "Please provide valid Password")]
        public string password { get; set; }

        [Required(ErrorMessage = "Please Confirm the Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password, ErrorMessage = "Password does not match")]
        public string confirmpassword { get; set; }
    }
}
