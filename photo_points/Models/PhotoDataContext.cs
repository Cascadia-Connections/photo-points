﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using photo_points.Models;

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


        //TODO: on VS-MAC use the reference https://www.ciclosoftware.com/2018/03/14/sql-server-with-net-core-and-entityframework-on-mac/
        //TODO: Update with your Database, User, and Password
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // it will be done after we start using our data//
            
            if (Environment.GetEnvironmentVariable("") == "") // // within the quotes, add the environment name

                optionsBuilder.UseSqlServer("Server=localhost,1433; Database=BitData;User=SA; Password=<YourStrong!Passw0rd>");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTag>().HasKey(sc => new { sc.userID, sc.tagID });
        }
        public DbSet<photo_points.Models.UserTag> UserTag { get; set; }
    }


}