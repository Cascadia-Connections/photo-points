using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class PhotoPoint
    {
        public long photoPointID { get; set; }

        [Display(Name = "Location Name")]
        [Required(ErrorMessage = "Location name is required.")]
        public string locationName { get; set; }

        public FeatureType feature { get; set; }

        public ICollection<Capture> captures { get; set; }

        //Designate the feature type.
    }
}