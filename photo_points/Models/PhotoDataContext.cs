using Microsoft.EntityFrameworkCore;
using System;

namespace photo_points.Models
{
    public class PhotoDataContext : DbContext
    {
        public PhotoDataContext(DbContextOptions<PhotoDataContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        //Access to Collections representing DB tables
        public DbSet<User> Users { get; set; }

        public DbSet<Capture> Captures { get; set; }
        public DbSet<PhotoPoint> PhotoPoints { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<UserTag> UserTags { get; set; }
        public DbSet<CaptureData> CaptureDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTag>()
                .HasKey(ut => new { ut.UserID, ut.TagID });
            modelBuilder.Entity<UserTag>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UserTags)
                .HasForeignKey(bc => bc.UserID);
            modelBuilder.Entity<UserTag>()
                .HasOne(bc => bc.Tag)
                .WithMany(c => c.UserTags)
                .HasForeignKey(bc => bc.TagID);

            modelBuilder.Entity<CaptureData>()
    .HasKey(cd => new { cd.CaptureID, cd.DataID });
            modelBuilder.Entity<CaptureData>()
                .HasOne(cd => cd.Capture)
                .WithMany(e => e.CaptureDatas)
                .HasForeignKey(bc => bc.CaptureID);
            modelBuilder.Entity<CaptureData>()
                .HasOne(bc => bc.Data)
                .WithMany(c => c.CaptureDatas)
                .HasForeignKey(bc => bc.DataID);
        }

        //TODO: on VS-MAC use the reference https://www.ciclosoftware.com/2018/03/14/sql-server-with-net-core-and-entityframework-on-mac/
        //TODO: Update with your Database, User, and Password

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // it will be done after we start using our data//
            // optionsBuilder.EnableSensitiveDataLogging(true);

            if (Environment.GetEnvironmentVariable("") == "") // // within the quotes, add the environment name

                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=BitData;User=SA; Password=<YourStrong!Passw0rd>");
        }
    }
}