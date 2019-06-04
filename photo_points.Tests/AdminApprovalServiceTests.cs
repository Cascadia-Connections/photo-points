using System;
using photo_points;
using photo_points.Models;
//<<<<<<< HEAD // //not sure if this line of code was important
using photo_points.Repositories; // added from issue #47
//======= // //not sure if this line of code was important
using photo_points.Repositories;
//>>>>>>> be76c438347a37c0012ee223681792bd372510f5 // //not sure if this line of code was important
using photo_points.Services;
using Xunit;

namespace photo_points.Tests
{
    public class AdminApprovalServiceTests
    {

        private IAdminReviewServices Subject()
        {
            var fakeAdminRepo = new FakeAdminReviewRepository();

            return new AdminReviewServices(fakeAdminRepo);
        }

        [Fact]
        public void IsAdminApproval_Valid()
        {

          var service = Subject();
          var isValid = service.approve(2);
          Assert.Equal(isValid,false);


        }

    }
}


