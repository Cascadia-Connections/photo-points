using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using photo_points.Models;

namespace photo_points.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project



        // FakePhotoRepository And IPhotoRepository changed by Eric's Codes//
    public class FakeAdminRepository : IAdminReviewServicesRepository
    {


        private DateTime DateTime(int v)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Capture> captures => new List<Capture> {
            new Capture { photo = 240, captureDate = DateTime (4/25/2019) },
            new Capture { photo = 240, captureDate = DateTime (3/13/2019) },
            new Capture { photo = 240, captureDate = DateTime(2/3/2019) }
        }.AsQueryable<Capture>();

       

        public IQueryable<User> users => new List<User> {
            new User { firstName = "Sara", lastName = "Ansari" },
            new User { firstName = "Sim", lastName = "Ruble" },
            new User { firstName = "Willie", lastName = "Weber" }
        }.AsQueryable<User>();

        public IQueryable<Capture> Captures => throw new NotImplementedException();

        public IQueryable<Data> Datas => throw new NotImplementedException();

        public IQueryable<PhotoPoint> PhotoPoints => throw new NotImplementedException();
    }
}