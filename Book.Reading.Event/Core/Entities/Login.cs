using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Book.Reading.Event.Core.Entities
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter your User Name")]
        [Display(Name = "User Name")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Please Provide a Valid Password")]
        public string password { get; set; }
    }
}
