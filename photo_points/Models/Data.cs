using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Data
{
    public long dataID { get; set; }
    public long captureID { get; set; }
    public string featureStatus { get; set; }
    public string featureHealth { get; set; }


    //Contest Rating
    public int phenologyScore { get; set; }
    public int creativityScore { get; set; }
    public int scienceSelfieScore { get; set; }
    public int overallScore { get; set; }
    public WinnerType winner { get; set; }

    //Designate the types of winners

    public enum WinnerType
    {
        PhenologyWinner,
        CreativityWinner,
        ScienceSelfieWinner,
        OverallWinner
    }
}
}
