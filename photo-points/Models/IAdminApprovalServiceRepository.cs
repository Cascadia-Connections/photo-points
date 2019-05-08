using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public interface IAdminApprovalServiceRepository
{
        IQueryable<Capture> Captures { get; }
        IQueryable<Data> Datas { get; }
        IQueryable<PhotoPoint> PhotoPoints { get; }
}
}
