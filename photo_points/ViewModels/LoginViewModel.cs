using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace photo_points.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Username (Email)")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "*")]
        public string UserName { get; set; }

        [Display(AutoGenerateField = true)]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
    
}
