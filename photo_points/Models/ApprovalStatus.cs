using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public enum ApprovalStatus
    {
        //Pending is the default. So when a new capture is created it will be waiting for admin approval.

        Pending,
        Approve,
        Reject
    }
}
