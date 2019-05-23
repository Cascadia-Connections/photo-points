using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace photo_points.Models
{
    public interface IAdminReviewServices
{
        bool approve(long CaptureId);
        IQueryable<Capture> GetAllCaptures();
        IEnumerable<Capture> GetUnapprovedCaptures();
        
        // IQueryable<Data> Datas { get; }
        // IQueryable<PhotoPoint> PhotoPoints { get; }
}