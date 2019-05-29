using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace photo_points.Models
{
    public class PhotoPoint
{
    public long photoPointID { get; set; }
    public string locationName { get; set; }
    public FeatureType feature { get; set; }

    public ICollection<Capture> captures { get; set; }

    //Designate the feature type.

    public enum FeatureType
    {
        Tree,
        Bush,
        Fern,
        Stream,
        Flower,
        Leaves
    }
}
}
