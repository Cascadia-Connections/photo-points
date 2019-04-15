using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class User
    {

        public long UserId { get; set; }

        [Required(ErrorMessage = "* required")]
        public string Name { get; set; }


        [Required(ErrorMessage = "* required")]
        public string Email { get; set; }

        public int Age { get; set; }


        public ICollection<Photopoint> Photopoints { get; set; }
    }
}
