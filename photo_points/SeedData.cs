using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using photo_points.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace photo_points
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await Seed(services.GetRequiredService<PhotoDataContext>());
        }

        public static async Task Seed(PhotoDataContext context)
        {
            if (context.Users.Any())
            {
                return; //already has data, don't add any more test data
            }

            Randomizer.Seed = new Random(8672042);

            byte[] imgdata = System.IO.File.ReadAllBytes("wwwroot/images/maple-leaf-888807_640.jpg");

            byte[] imgdata1 = System.IO.File.ReadAllBytes("wwwroot/images/blackberry-flower-4070045_640.jpg");

            byte[] imgdata2 = System.IO.File.ReadAllBytes("wwwroot/images/fern-1105988_640.jpg");

            var captures = new List<Capture> {
                new Capture
                {
                    Photo = imgdata,
                    CaptureDate = DateTime.Now,
                    Approval=Capture.ApprovalType.Pending,
                    PhotoPoint=
                    CreatePhotoPoint(PhotoPoint.FeatureType.Leaves, "Oak Trees #1"),
                    User=
                    CreateUser(),
                    Tags=new List<Tag>
                    {
                        CreateTag("Leaves Falling"),
                        CreateTag("On Track")
                    },
                    Data=new List<Data>
                    {
                       CreateData("Color", "Green"),
                       CreateData("Color", "Red"),
                    }
                },
                  new Capture
                {
                    Photo = imgdata1,
                    CaptureDate = DateTime.Now,
                    Approval=Capture.ApprovalType.Approve,
                    PhotoPoint=
                    CreatePhotoPoint(PhotoPoint.FeatureType.Leaves, "Fern"),
                    User=
                    CreateUser(),
                    Tags=new List<Tag>
                    {
                        CreateTag("New Fern"),
                        CreateTag("Fern Falling")
                    },
                    Data=new List<Data>
                    {
                       CreateData("Color", "Green"),
                       CreateData("Style", "Solid"),
                    }
                },
                    new Capture
                {
                    Photo = imgdata2,
                    CaptureDate = DateTime.Now,
                    Approval=Capture.ApprovalType.Pending,
                    PhotoPoint=
                    CreatePhotoPoint(PhotoPoint.FeatureType.Leaves, "BlackBerry"),
                    User=CreateUser(),
                    Tags=new List<Tag>
                    {
                        CreateTag("Leaves Falling"),
                        CreateTag("On Track")
                    },
                    Data=new List<Data>
                    {
                       CreateData("Color", "Green"),
                       CreateData("Color", "Purple"),
                    }
                },

            };

        await context.Captures.AddRangeAsync(captures);
            
            await context.SaveChangesAsync();
        }
        public static Data CreateData(string type, string value)
        {
            Data newData = new Data();
            newData.type = type;
            newData.value = value;
            return newData;
        }

        public static User CreateUser()
        {
            var faker = new Faker();
            var fakeUser = new User
            {
                firstName = faker.Name.FirstName(),
                lastName = faker.Name.LastName(),
                email = faker.Internet.Email(),
                password = faker.Internet.Password()
            };

            return fakeUser;
        }
        
        public static Tag CreateTag(string tagName)
        {
            Tag tag = new Tag
            {
                tagName = tagName
            };

            return tag;
        }
        public static PhotoPoint CreatePhotoPoint(PhotoPoint.FeatureType feature, string locationName)
        {
            PhotoPoint photoPoint = new PhotoPoint
            {
                feature = feature,
                locationName = locationName
            };

            return photoPoint;
        }

    }
}