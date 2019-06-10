using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class Data
{
    public long dataID { get; set; }
    [Display(Name = "Data Type")]
    public string type { get; set; }
    [Display(Name = "Value of Data")]
    public string value { get; set; }
    [Display(Name = "Comments")]
    public string comment { get; set; }

    public Capture Capture { get; set; }


    ////Contest Rating
    //public int phenologyScore { get; set; }
    //public int creativityScore { get; set; }
    //public int scienceSelfieScore { get; set; }
    //public int overallScore { get; set; }
    //public WinnerType winner { get; set; }

    ////Designate the types of winners

    //public enum WinnerType
    //{
    //    PhenologyWinner,
    //    CreativityWinner,
    //    ScienceSelfieWinner,
    //    OverallWinner
    //}
}
}
