using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Note
    {
        public long noteID { get; set; }
        [Display(Name = "Add Note")]
        public string noteComment { get; set; }
        public Capture Capture { get; set; }
    }
}
