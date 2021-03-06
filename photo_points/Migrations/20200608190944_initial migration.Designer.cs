﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using photo_points.Models;

namespace photo_points.Migrations
{
    [DbContext(typeof(PhotoDataContext))]
    [Migration("20200608190944_initial migration")]
    partial class initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("photo_points.Models.Capture", b =>
                {
                    b.Property<long>("CaptureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Approval")
                        .HasColumnType("int");

                    b.Property<DateTime>("CaptureDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<long?>("PhotoPointID")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("CaptureId");

                    b.HasIndex("PhotoPointID");

                    b.HasIndex("UserID");

                    b.ToTable("Captures");
                });

            modelBuilder.Entity("photo_points.Models.Data", b =>
                {
                    b.Property<long>("DataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CaptureId")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DataID");

                    b.HasIndex("CaptureId");

                    b.ToTable("Datas");
                });

            modelBuilder.Entity("photo_points.Models.Note", b =>
                {
                    b.Property<long>("noteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CaptureId")
                        .HasColumnType("bigint");

                    b.Property<string>("noteComment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("noteID");

                    b.HasIndex("CaptureId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("photo_points.Models.PhotoPoint", b =>
                {
                    b.Property<long>("PhotoPointID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Feature")
                        .HasColumnType("int");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhotoPointID");

                    b.ToTable("PhotoPoints");
                });

            modelBuilder.Entity("photo_points.Models.Tag", b =>
                {
                    b.Property<long>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CaptureId")
                        .HasColumnType("bigint");

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UserID")
                        .HasColumnType("bigint");

                    b.HasKey("TagID");

                    b.HasIndex("CaptureId");

                    b.HasIndex("UserID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("photo_points.Models.User", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("photo_points.Models.Capture", b =>
                {
                    b.HasOne("photo_points.Models.PhotoPoint", "PhotoPoint")
                        .WithMany("Captures")
                        .HasForeignKey("PhotoPointID");

                    b.HasOne("photo_points.Models.User", "User")
                        .WithMany("Captures")
                        .HasForeignKey("UserID");
                });

            modelBuilder.Entity("photo_points.Models.Data", b =>
                {
                    b.HasOne("photo_points.Models.Capture", "Capture")
                        .WithMany("Data")
                        .HasForeignKey("CaptureId");
                });

            modelBuilder.Entity("photo_points.Models.Note", b =>
                {
                    b.HasOne("photo_points.Models.Capture", "Capture")
                        .WithMany()
                        .HasForeignKey("CaptureId");
                });

            modelBuilder.Entity("photo_points.Models.Tag", b =>
                {
                    b.HasOne("photo_points.Models.Capture", "Capture")
                        .WithMany("Tags")
                        .HasForeignKey("CaptureId");

                    b.HasOne("photo_points.Models.User", "User")
                        .WithMany("Tags")
                        .HasForeignKey("UserID");
                });
#pragma warning restore 612, 618
        }
    }
}
