using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace photo_points.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FakePhotoRepository : 
    {
        public IQueryable<Capture> captures => new List<Capture> {
            new Capture { photo = 240, captureDate = 4/25/2019 },
            new Capture { photo = 240, captureDate = 3/13/2019 },
            new Capture { photo = 240, captureDate = 2/3/2019 }
        }.AsQueryable<Capture>();


        public IQueryable<User> users => new List<User> {
            new User { firstName = "Sara", lastName = "Ansari" },
            new User { firstName = "Sim", lastName = "Ruble" },
            new User { firstName = "Willie", lastName = "Weber" }
        }.AsQueryable<User>();
    }
}