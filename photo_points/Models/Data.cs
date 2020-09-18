using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Data
    {
        public long DataID { get; set; }

        [Display(Name = "Data Type")]
        public string Type { get; set; }

        [Display(Name = "Value of Data")]
        public string Value { get; set; }

        [Display(Name = "Comments")]
        public string Comment { get; set; }
        public long CaptureId { get; set; }
    }
}