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
    public byte photo { get; set; }
    public DateTime captureDate { get; set; }
    
    public ICollection<Data> data { get; set; }
    public ICollection<Tag> tags {get; set; }
    public User user { get; set; }
    public PhotoPoint PhotoPoint { get; set; }
}
}
