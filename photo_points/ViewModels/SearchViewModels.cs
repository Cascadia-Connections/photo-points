﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.ViewModels
{
    public class SearchViewModels
    {
        // // need to add to controllers to convert to the view 
        public long photoPointId { get; set; } // create action in controller to feed the view the information
        public string imageSource { get; set; } // this may need to be renamed // // PendingViewModels has a public string ImageSource{get; set;}
        public DateTime fromDate { get; set; } 
        public DateTime toDate { get; set; }
        public string tagName { get; set; }



    }
}