using photo_points.Models;
using System;
using System.Collections.Generic;

namespace photo_points.ViewModels
{
    public class SearchViewModel
    {
        // // need to add to controllers to convert to the view
        public long photoPointId { get; set; } // create action in controller to feed the view the information

        public string imageSource { get; set; } // this may need to be renamed // // PendingViewModels has a public string ImageSource{get; set;}
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string tagName { get; set; }
        public ApprovalType approval { get; set; }

        public enum ApprovalType
        {
            //Pending is the default. So when a new capture is created it will be waiting for admin approval.

            Pending,
            Approved,
            Rejected
        }

        public List<Capture> SearchCaptures { get; set; }
    }
}