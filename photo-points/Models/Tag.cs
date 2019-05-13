using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks; 

namespace photo_points.Models
{
    public class Tag
    {
        public long tagID { get; set; }
        public string tagName { get; set; }

        public ICollection<Capture> captures { get; set; }
        public ICollection<User> users { get; set; }

    }
}
