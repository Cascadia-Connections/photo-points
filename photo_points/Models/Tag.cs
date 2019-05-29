using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Tag
    {
        public long tagID { get; set; }
        [Required]
        public string tagName { get; set; }

        public ICollection<User> users { get; set; }
        public ICollection<Capture> captures { get; set; }
    }
}
