using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class User
{
    public long userID { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }

    public ICollection<Capture> captures { get; set; }
    public ICollection<Tag> tags { get; set; }

}
}
