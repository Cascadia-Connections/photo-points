using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{

    public class UserTag
    {
        public long TagID { get; set; }
        public Tag Tag { get; set; }

        public long UserID { get; set; }
        public User User { get; set; }
    }
}