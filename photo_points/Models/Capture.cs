using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Capture
<<<<<<< HEAD
    {
        public long captureID { get; set; }
        public byte[] photo { get; set; }
        public DateTime captureDate { get; set; }

        //Determines whether a photo should be displayed.
        public ApprovalType approval { get; set; }

        public enum ApprovalType
        {
=======
{
    public long captureID { get; set; }
    public byte[] photo { get; set; }
    public DateTime captureDate { get; set; }

    //Determines whether a photo should be displayed.
    public ApprovalType approval { get; set; }

    public enum ApprovalType
        {
            //Pending is the default. So when a new capture is created it will be waiting for admin approval.
>>>>>>> 458fdf9d52ae1eebd8a61facf05fe1916d1c53f9
            Pending,
            Approve,
            Reject
        }
<<<<<<< HEAD

        public ICollection<Data> data { get; set; }
        public ICollection<Tag> tags { get; set; }
        public User user { get; set; }
        public PhotoPoint PhotoPoint { get; set; }
    }
}
=======
    
    public ICollection<Data> data { get; set; }
    public ICollection<Tag> tags {get; set; }
    public User user { get; set; }
    public PhotoPoint PhotoPoint { get; set; } 
}
}
>>>>>>> 458fdf9d52ae1eebd8a61facf05fe1916d1c53f9
