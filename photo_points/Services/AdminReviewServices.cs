using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points.Models
{
    public class AdminReviewServices
    {
        private IAdminReviewRepository _capturerepo;

        public AdminReviewServices(IAdminReviewRepository capturerepo)
        {
            _capturerepo = capturerepo;
        }

        public IQueryable<Capture> GetAllCaptures()
        {
            return _capturerepo.GetCaptures();
        }
    }
}
