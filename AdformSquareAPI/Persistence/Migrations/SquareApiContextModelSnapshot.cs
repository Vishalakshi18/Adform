﻿// <auto-generated />
using AdformSquareAPI.Persitence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdformSquareAPI.Persistence.Migrations
{
    [DbContext(typeof(SquareApiContext))]
    partial class SquareApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("AdformSquareAPI.Core.Model.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("X")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Y")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("AdformSquareAPI.Core.Model.Square", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Point1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Point2Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Point3Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Point4Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Point1Id");

                    b.HasIndex("Point2Id");

                    b.HasIndex("Point3Id");

                    b.HasIndex("Point4Id");

                    b.ToTable("Square");
                });

            modelBuilder.Entity("AdformSquareAPI.Core.Model.Square", b =>
                {
                    b.HasOne("AdformSquareAPI.Core.Model.Point", "Point1")
                        .WithMany()
                        .HasForeignKey("Point1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdformSquareAPI.Core.Model.Point", "Point2")
                        .WithMany()
                        .HasForeignKey("Point2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdformSquareAPI.Core.Model.Point", "Point3")
                        .WithMany()
                        .HasForeignKey("Point3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdformSquareAPI.Core.Model.Point", "Point4")
                        .WithMany()
                        .HasForeignKey("Point4Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point1");

                    b.Navigation("Point2");

                    b.Navigation("Point3");

                    b.Navigation("Point4");
                });
#pragma warning restore 612, 618
        }
    }
}
