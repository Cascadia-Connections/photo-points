using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class User
    {
        public long userID { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string lastName { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }
        public string password { get; set; }
        public Role Role { get; set; }
        public ICollection<Capture> captures { get; set; }
    public ICollection<Tag> tags { get; set; }

}
}
