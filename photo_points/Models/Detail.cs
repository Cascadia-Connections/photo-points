using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Detail
    {
        public long DetailID { get; set; }

        [Display(Name = "Data Type")]
        public string Type { get; set; }

        [Display(Name = "Value of Data")]
        public string Value { get; set; }

        [Display(Name = "Comments")]
        public string Comment { get; set; }

        public Capture Capture { get; set; }
    }
}