using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class CaptureData
    {
        public long CaptureID { get; set; }
        public Capture Capture { get; set; }

        public long DataID { get; set; }
        public Data Data { get; set; }
    }
}
