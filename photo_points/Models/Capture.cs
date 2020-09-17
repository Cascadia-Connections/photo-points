using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Capture
    {
        public long CaptureId { get; set; }

        [Display(Name = "Upload Photo")]
        [Required(ErrorMessage = "Must add a photo.")]
        [DataType(DataType.ImageUrl)]
        public byte[] Photo { get; set; }

        public DateTime CaptureDate { get; set; }

        //Determines whether a photo should be displayed.
        public ApprovalStatus Approval { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public User User { get; set; }
        public PhotoPoint PhotoPoint { get; set; }
        public ICollection<CaptureData> CaptureDatas { get; set; }
    }
}