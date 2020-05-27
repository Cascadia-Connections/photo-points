using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Capture { 

    public long CaptureId { get; set; }
    [Display(Name = "Upload Photo")]
    [Required(ErrorMessage = "Must add a photo.")]
    [DataType(DataType.ImageUrl)]
    public byte[] Photo { get; set; }
    public DateTime CaptureDate { get; set; }

    //Determines whether a photo should be displayed.
    public ApprovalType Approval { get; set; }

    public enum ApprovalType
        {
            //Pending is the default. So when a new capture is created it will be waiting for admin approval.

            Pending,
            Approve,
            Reject
        }

        public ICollection<Data> Data { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public User User { get; set; }
        public PhotoPoint PhotoPoint { get; set; }
    }
}