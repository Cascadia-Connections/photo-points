using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class User
{
    public long userID { get; set; }
    [Required]
    public string firstName { get; set; }
    [Required]
    public string lastName { get; set; }
    [Required]
    public string email { get; set; }

    public ICollection<Capture> captures { get; set; }
    public ICollection<Tag> tags { get; set; }

}
}
