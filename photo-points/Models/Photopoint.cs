using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Photopoint
    {

        public long PhotoId { get; set; }

        [Required(ErrorMessage = "* required")]
        public string photopoint { get; set; }

        [Required(ErrorMessage = "* required")]
        public string PhotoName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime PhotoDate { get; set; }

        [Required(ErrorMessage = "* required")]
        public string Comments { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}