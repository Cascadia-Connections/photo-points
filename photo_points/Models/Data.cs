using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Data
    {
        public long DataID { get; set; }
        [Required]
        [Display(Name = "Data Type")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Value of Data")]
        public string Value { get; set; }

        [Display(Name = "Comments")]
        public string Comment { get; set; }
        [Required]
        public long CaptureId { get; set; }
    }
}