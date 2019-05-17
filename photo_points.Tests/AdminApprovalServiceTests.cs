using System;
using photo_points.Models;
using photo_points.Services;
using Xunit;

namespace photo_points.Tests
{
    public class AdminApprovalServiceTests
    {


        private AdminReviewServices Subject()
        {
            var fakeAdminRepo = new FakeAdminRepository();

            return new AdminReviewServices(fakeAdminRepo);
        }

        [Fact]
        public void IsAdminApproval_Valid(long captureID, byte photo, DateTime captureDate, bool Approved)
        {

          var service = Subject();
          var isValid = service.approve(captureID, photo, captureDate, Approved);
          Assert.True(Approved);


        }


    }
}


