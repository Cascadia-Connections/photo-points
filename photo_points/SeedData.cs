using Bogus;
using Microsoft.Extensions.DependencyInjection;
using photo_points.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    Approval=ApprovalStatus.Pending,
                    PhotoPoint=
                    CreatePhotoPoint(FeatureType.Leaves, "Oak Trees #1"),
                    User=
                    CreateUser(),
                    Tags=new List<Tag>
                    {
                        CreateTag("Leaves Falling, Cherry Tree"),
                        CreateTag("On Track")
                    },
                },
                  new Capture
                {
                    Photo = imgdata1,
                    CaptureDate = DateTime.Now,
                    Approval=ApprovalStatus.Approve,
                    PhotoPoint=
                    CreatePhotoPoint(FeatureType.Leaves, "Fern"),
                    User=
                    CreateUser(),
                    Tags=new List<Tag>
                    {
                        CreateTag("New Fern"),
                        CreateTag("Fern Falling, Sword Fern")
                    },
                },
                    new Capture
                {
                    Photo = imgdata2,
                    CaptureDate = DateTime.Now,
                    Approval=ApprovalStatus.Pending,
                    PhotoPoint=
                    CreatePhotoPoint(FeatureType.Leaves, "BlackBerry"),
                    User=
                    CreateUser(),
                    Tags=new List<Tag>
                    {
                        CreateTag("Leaves Falling, Maple Tree"),
                        CreateTag("On Track")
                    },
                }
            };

            List<UserTag> uTags = CreateUserTags();
            List<Data> datas = CreateDatas();

            await context.Captures.AddRangeAsync(captures);
            await context.SaveChangesAsync();

            await context.UserTags.AddRangeAsync(uTags);
            await context.SaveChangesAsync();

            await context.Datas.AddRangeAsync(datas);
            await context.SaveChangesAsync();
        }

        public static Data CreateData(long cid, string type, string value)
        {
            Data newData = new Data
            {
                CaptureId = cid,
                Type = type,
                Value = value
            };
            return newData;
        }

        public static User CreateUser()
        {
            var faker = new Faker();
            var fakeUser = new User
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                Email = faker.Internet.Email(),
                Password = faker.Internet.Password(),
            };

            return fakeUser;
        }

        public static Tag CreateTag(string tagName)
        {
            Tag tag = new Tag
            {
                TagName = tagName
            };

            return tag;
        }

        public static List<UserTag> CreateUserTags()
        {
            List<UserTag> userTags = new List<UserTag>
            {
                new UserTag
                {
                    UserID = 1,
                    TagID = 1
                },
                new UserTag
                {
                    UserID = 1,
                    TagID = 2
                },
                new UserTag
                {
                    UserID = 1,
                    TagID = 3
                },
                new UserTag
                {
                    UserID = 1,
                    TagID = 4
                },
                new UserTag
                {
                    UserID = 1,
                    TagID = 5
                }
            };
            return userTags;
        }

        public static List<Data> CreateDatas()
        {
            List<Data> datas = new List<Data>
            {
                CreateData(1, "Stream Width", "30cm"),
                CreateData(1, "Stream Length", "30m"),
                CreateData(1, "Stream Depth", "1m"),
                CreateData(2, "Stem Width", "3cm"),
                CreateData(2, "Stem Length", "35cm"),
                CreateData(2, "Stem Flowers", "3"),
                CreateData(2, "Stem Color", "Greenish Yellow")
            };
            return datas;
        }

        public static PhotoPoint CreatePhotoPoint(FeatureType feature, string locationName)
        {
            PhotoPoint photoPoint = new PhotoPoint
            {
                Feature = feature,
                LocationName = locationName
            };
            return photoPoint;
        }
    }
}