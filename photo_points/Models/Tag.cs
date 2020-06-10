using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Tag
    {
        public long TagID { get; set; }

        [Display(Name = "Tag Name")]
        [Required(ErrorMessage = "Tag name is required.")]
        public string TagName { get; set; }
        public Capture Capture { get; set; }
        public ICollection<UserTag> UserTags {get; set;}
    }
}