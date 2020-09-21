using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace photo_points.Models
{
    public class PhotoPoint
    {
        public long PhotoPointID { get; set; }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name is required.")]
        public string LocationName { get; set; }

        public FeatureType Feature { get; set; }

        //Designate the feature type.
    }
}