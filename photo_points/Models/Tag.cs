using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Tag
    {
        public long TagID { get; set; }

        [Display(Name = "Tag Name")]
        [Required(ErrorMessage = "Tag name is required.")]
        public string TagName { get; set; }

        public User user { get; set; }
        public Capture capture { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<UserTag> UserTag { get; set; }
    }
}