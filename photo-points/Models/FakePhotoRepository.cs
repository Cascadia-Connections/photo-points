using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace photo_points.Models
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class FakePhotoRepository : IProductRepository
    {
        public IQueryable<Photo> photos => new List<Photo> {
            new Product { Name = "Football", Price = 25 },
            new Product { Name = "Surf board", Price = 179 },
            new Product { Name = "Running shoes", Price = 95 }
        }.AsQueryable<Photo>();
    }
