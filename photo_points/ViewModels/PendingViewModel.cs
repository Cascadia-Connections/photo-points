using photo_points.Models;
using System.Collections.Generic;

namespace photo_points.ViewModels
{
    public class PendingViewModel
    {
        public List <Capture> PendingCaptures { get; set; }
        public List <string> ImageSource { get; set; }//generic
    }
}
