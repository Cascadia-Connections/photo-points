using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class PhotoPoint
    {
        public long PhotoPointID { get; set; }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name is required.")]
        public string LocationName { get; set; }

        public FeatureType Feature { get; set; }

        public ICollection<Capture> Captures { get; set; }

        //Designate the feature type.
    }
}