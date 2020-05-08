using Microsoft.EntityFrameworkCore;
using photo_points.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace photo_points
{
    public static class PhotoDataBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Capture>()
                .HasData(
                new 
                {
                    captureID = 1,
                    photo = System.IO.File.ReadAllBytes("wwwroot/images/maple-leaf-888807_640.jpg"),
                    captureDate = DateTime.Now,
                    approval = Capture.ApprovalType.Pending,
                    PhotoPoint = new PhotoPoint() { photoPointID = 1, locationName = "Oak Trees #1", feature = PhotoPoint.FeatureType.Leaves },
                    user = new User() { firstName = "Tom", lastName = "Jones" },
                    tags = new List<Tag>() { { new Tag() { tagID = 0, tagName = "Leaves Falling" } }, new Tag() { tagID = 1, tagName = "On Track" } },
                    data = new List<Data>() { { new Data() { dataID = 0, type = "Color", value = "Green" } } }
                },
                new Capture
                {
                    captureID = 2,
                    photo = System.IO.File.ReadAllBytes("wwwroot/images/blackberry-flower-4070045_640.jpg"),
                    captureDate = DateTime.Now,
                    approval = Capture.ApprovalType.Pending,
                    PhotoPoint = new PhotoPoint() { photoPointID = 2, feature = PhotoPoint.FeatureType.Bush, locationName = "Branches" },
                    user = new User() { firstName = "Tom", lastName = "Jones" },
                    tags = new List<Tag>() { { new Tag() { tagID = 0, tagName = "Leaves Falling" } }, new Tag() { tagID = 1, tagName = "On Track" } },
                    data = new List<Data>() { { new Data() { dataID = 0, type = "Color", value = "Green" } } }
                },
                new Capture
                {
                    captureID = 3,
                    photo = System.IO.File.ReadAllBytes("wwwroot/images/fern-1105988_640.jpg"),
                    captureDate = DateTime.Now,
                    approval = Capture.ApprovalType.Pending,
                    PhotoPoint = new PhotoPoint() { photoPointID = 3, feature = PhotoPoint.FeatureType.Fern, locationName = "Something else" },
                    user = new User() { firstName = "Tom", lastName = "Jones" },
                    tags = new List<Tag>() { { new Tag() { tagID = 0, tagName = "Leaves Falling" } }, new Tag() { tagID = 1, tagName = "On Track" } },
                    data = new List<Data>() { { new Data() { dataID = 0, type = "Color", value = "Green" } } }
                }
        );
        }
    }
}
