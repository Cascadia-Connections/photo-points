using System;
using photo_points;
using photo_points.Models;
using photo_points.Services;
using Xunit;

namespace photo_points.Tests
{
    public class AdminApprovalServiceTests
    {


        private IAdminReviewServices Subject()
        {
            var fakeAdminRepo = new FakeAdminRepository();

            return new AdminReviewServices(fakeAdminRepo);
        }

        [Fact]
        public void IsAdminApproval_Valid()
        {

          var service = Subject();
          var isValid = service.approve(2);
          Assert.Equal(isValid,actual);


        }


    }
}


