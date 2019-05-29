using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Capture
{
    public long captureID { get; set; }
    [Display(Name = "Upload Photo")]
    [Required(ErrorMessage = "Must add a photo.")]
    [DataType(DataType.ImageUrl)]
    public byte[] photo { get; set; }
    public DateTime captureDate { get; set; }

    //Determines whether a photo should be displayed.
    public ApprovalType approval { get; set; }

    public enum ApprovalType
        {
            //Pending is the default. So when a new capture is created it will be waiting for admin approval.
            Pending,
            Approve,
            Reject
        }
    
    public ICollection<Data> data { get; set; }
    public ICollection<Tag> tags {get; set; }
    [Required(ErrorMessage = "Must have a user.")]
    public User user { get; set; }
    [Required(ErrorMessage = "Must have a PhotoPoint")]
    public PhotoPoint PhotoPoint { get; set; } 
}
}
