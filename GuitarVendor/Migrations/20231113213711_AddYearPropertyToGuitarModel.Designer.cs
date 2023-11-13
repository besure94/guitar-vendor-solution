﻿// <auto-generated />
using GuitarVendor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuitarVendor.Migrations
{
    [DbContext(typeof(GuitarVendorContext))]
    [Migration("20231113213711_AddYearPropertyToGuitarModel")]
    partial class AddYearPropertyToGuitarModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GuitarVendor.Models.Guitar", b =>
                {
                    b.Property<int>("GuitarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Brand")
                        .HasColumnType("longtext");

                    b.Property<string>("Color")
                        .HasColumnType("longtext");

                    b.Property<string>("Model")
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("longtext");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("GuitarId");

                    b.HasIndex("StoreId");

                    b.ToTable("Guitars");
                });

            modelBuilder.Entity("GuitarVendor.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("StoreId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("GuitarVendor.Models.Guitar", b =>
                {
                    b.HasOne("GuitarVendor.Models.Store", "Store")
                        .WithMany("Guitars")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("GuitarVendor.Models.Store", b =>
                {
                    b.Navigation("Guitars");
                });
#pragma warning restore 612, 618
        }
    }
}
