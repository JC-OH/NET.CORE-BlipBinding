﻿// <auto-generated />
using System;
using Blip.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blip.Data.Migrations
{
    [DbContext(typeof(BlipDbContext))]
    [Migration("20210402232550_initialize")]
    partial class initialize
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blip.Domain.Country", b =>
                {
                    b.Property<string>("Iso3")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("CountryNameEnglish")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Iso3");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Blip.Domain.Customer", b =>
                {
                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryIso3")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("RegionCode")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("RegionCode1")
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("CustomerID");

                    b.HasIndex("CountryIso3");

                    b.HasIndex("RegionCode1");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Blip.Domain.Item", b =>
                {
                    b.Property<Guid>("ItemID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<decimal>("MSRP")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReorderQuantity")
                        .HasColumnType("int");

                    b.HasKey("ItemID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Blip.Domain.Order", b =>
                {
                    b.Property<Guid>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Blip.Domain.OrderItem", b =>
                {
                    b.Property<Guid>("ItemID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OrderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint");

                    b.HasKey("ItemID", "OrderID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Blip.Domain.Region", b =>
                {
                    b.Property<string>("RegionCode")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("CountryIso3")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Iso3")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("RegionNameEnglish")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionCode");

                    b.HasIndex("CountryIso3");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("Blip.Domain.Customer", b =>
                {
                    b.HasOne("Blip.Domain.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryIso3")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blip.Domain.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionCode1");
                });

            modelBuilder.Entity("Blip.Domain.Order", b =>
                {
                    b.HasOne("Blip.Domain.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blip.Domain.OrderItem", b =>
                {
                    b.HasOne("Blip.Domain.Item", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Blip.Domain.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Blip.Domain.Region", b =>
                {
                    b.HasOne("Blip.Domain.Country", "Country")
                        .WithMany("Regions")
                        .HasForeignKey("CountryIso3");
                });
#pragma warning restore 612, 618
        }
    }
}
