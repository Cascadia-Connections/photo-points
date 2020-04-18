using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Tag
    {
        public long tagID { get; set; }
        [Display(Name = "Tag Name")]
        [Required(ErrorMessage = "Tag name is required.")]
        public string tagName { get; set; }

        public User user { get; set; }
        //public ICollection<Capture> captures { get; set; }
        public Capture capture { get; set; }
    }
}
