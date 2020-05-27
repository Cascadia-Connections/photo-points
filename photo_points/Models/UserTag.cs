using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class UserTag
    {
        public long tagID { get; set; }
        public Tag Tag { get; set; }

        public long userID { get; set; }
        public User User { get; set; }
    }
}
