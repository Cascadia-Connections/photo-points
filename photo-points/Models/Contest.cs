using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo-points.Models
{
    public class Contest
{
    public long contestID { get; set; }
    public int phenologyScore { get; set; }
    public int creativityScore { get; set; }
    public int scienceSelieScore { get; set; }
    public int overallScore { get; set; }
}
}
