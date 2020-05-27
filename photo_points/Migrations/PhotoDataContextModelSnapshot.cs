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
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("photo_points.Models.Capture", b =>
                {
                    b.Property<long>("captureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("approval")
                        .HasColumnType("int");

                    b.Property<DateTime>("captureDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long?>("photoPointID")
                        .HasColumnType("bigint");

                    b.Property<long?>("userID")
                        .HasColumnType("bigint");

                    b.HasKey("captureID");

                    b.HasIndex("photoPointID");

                    b.HasIndex("userID");

                    b.ToTable("Captures");
                });

            modelBuilder.Entity("photo_points.Models.Data", b =>
                {
                    b.Property<long>("dataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("captureID")
                        .HasColumnType("bigint");

                    b.Property<string>("comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("dataID");

                    b.HasIndex("captureID");

                    b.ToTable("Datas");
                });

            modelBuilder.Entity("photo_points.Models.PhotoPoint", b =>
                {
                    b.Property<long>("photoPointID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("feature")
                        .HasColumnType("int");

                    b.Property<string>("locationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("photoPointID");

                    b.ToTable("PhotoPoints");
                });

            modelBuilder.Entity("photo_points.Models.Tag", b =>
                {
                    b.Property<long>("tagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("captureID")
                        .HasColumnType("bigint");

                    b.Property<string>("tagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("userID")
                        .HasColumnType("bigint");

                    b.HasKey("tagID");

                    b.HasIndex("captureID");

                    b.HasIndex("userID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("photo_points.Models.User", b =>
                {
                    b.Property<long>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("tagID")
                        .HasColumnType("bigint");

                    b.HasKey("userID");

                    b.HasIndex("tagID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("photo_points.Models.UserTag", b =>
                {
                    b.Property<long>("userID")
                        .HasColumnType("bigint");

                    b.Property<long>("tagID")
                        .HasColumnType("bigint");

                    b.HasKey("userID", "tagID");

                    b.HasIndex("tagID");

                    b.ToTable("UserTags");
                });

            modelBuilder.Entity("photo_points.Models.Capture", b =>
                {
                    b.HasOne("photo_points.Models.PhotoPoint", "PhotoPoint")
                        .WithMany("captures")
                        .HasForeignKey("photoPointID");

                    b.HasOne("photo_points.Models.User", "user")
                        .WithMany()
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
                        .WithMany()
                        .HasForeignKey("userID");
                });

            modelBuilder.Entity("photo_points.Models.User", b =>
                {
                    b.HasOne("photo_points.Models.Tag", null)
                        .WithMany("Users")
                        .HasForeignKey("tagID");
                });

            modelBuilder.Entity("photo_points.Models.UserTag", b =>
                {
                    b.HasOne("photo_points.Models.Tag", "Tag")
                        .WithMany("UserTag")
                        .HasForeignKey("tagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("photo_points.Models.User", "User")
                        .WithMany("UserTag")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
