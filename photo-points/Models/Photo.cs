using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class Photo
    {

        public long PhotoId { get; set; }

        public long PhotoFile{ get; set; }



        public ICollection<Photopoint> photopoints { get; set; }
    }
}