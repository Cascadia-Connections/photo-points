﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using photo_points.Models;

namespace photo_points.Migrations
{
    [DbContext(typeof(PhotoDataContext))]
    partial class PhotoDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("photo_points.Models.Capture", b =>
                {
                    b.Property<long>("captureID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("approval");

                    b.Property<DateTime>("captureDate");

                    b.Property<byte[]>("photo")
                        .IsRequired();

                    b.Property<long?>("photoPointID");

                    b.Property<long?>("userID");

                    b.HasKey("captureID");

                    b.HasIndex("photoPointID");

                    b.HasIndex("userID");

                    b.ToTable("Captures");
                });

            modelBuilder.Entity("photo_points.Models.Data", b =>
                {
                    b.Property<long>("dataID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("captureID");

                    b.Property<string>("comment");

                    b.Property<string>("type");

                    b.Property<string>("value");

                    b.HasKey("dataID");

                    b.HasIndex("captureID");

                    b.ToTable("Datas");
                });

            modelBuilder.Entity("photo_points.Models.PhotoPoint", b =>
                {
                    b.Property<long>("photoPointID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("feature");

                    b.Property<string>("locationName")
                        .IsRequired();

                    b.HasKey("photoPointID");

                    b.ToTable("PhotoPoints");
                });

            modelBuilder.Entity("photo_points.Models.Tag", b =>
                {
                    b.Property<long>("tagID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("captureID");

                    b.Property<string>("tagName")
                        .IsRequired();

                    b.Property<long?>("userID");

                    b.HasKey("tagID");

                    b.HasIndex("captureID");

                    b.HasIndex("userID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("photo_points.Models.User", b =>
                {
                    b.Property<long>("userID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password");

                    b.Property<string>("email")
                        .IsRequired();

                    b.Property<string>("firstName")
                        .IsRequired();

                    b.Property<string>("lastName")
                        .IsRequired();

                    b.HasKey("userID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("photo_points.Models.Capture", b =>
                {
                    b.HasOne("photo_points.Models.PhotoPoint", "PhotoPoint")
                        .WithMany("captures")
                        .HasForeignKey("photoPointID");

                    b.HasOne("photo_points.Models.User", "user")
                        .WithMany("captures")
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("photo_points.Models.Data", b =>
                {
                    b.HasOne("photo_points.Models.Capture", "Capture")
                        .WithMany("data")
                        .HasForeignKey("captureID");
                });

            modelBuilder.Entity("photo_points.Models.Tag", b =>
                {
                    b.HasOne("photo_points.Models.Capture", "capture")
                        .WithMany("tags")
                        .HasForeignKey("captureID");

                    b.HasOne("photo_points.Models.User", "user")
                        .WithMany("tags")
                        .HasForeignKey("userID");
                });
#pragma warning restore 612, 618
        }
    }
}
