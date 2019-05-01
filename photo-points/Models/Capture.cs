using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Capture
{
    public long captureID { get; set; }
    public byte photo { get; set; }
    public DateTime captureDate { get; set; }
    public long photoPointID { get; set; }
    public long userID { get; set; }

    public ICollection<Data> ppData { get; set; }

}
}
