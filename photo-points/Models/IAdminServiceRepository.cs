using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public interface IAdminServiceRepository
    {
        IQueryable<Capture> Captures { get; }
        IQueryable<Data> Datas { get; }
        IQueryable<PhotoPoint> PhotoPoints { get; }

        // // // above code should be uncommented before submission
    }
}
