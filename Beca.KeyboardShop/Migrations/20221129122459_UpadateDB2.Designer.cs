﻿// <auto-generated />
using System;
using Beca.KeyboardShop.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Beca.KeyboardShop.Migrations
{
    [DbContext(typeof(KeyboardShopDbContext))]
    [Migration("20221129122459_UpadateDB2")]
    partial class UpadateDB2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Beca.KeyboardShop.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Slim"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mechanical"
                        });
                });

            modelBuilder.Entity("Beca.KeyboardShop.Entities.Keyboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Discounter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int?>("OfferInSeconds")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OrderId");

                    b.ToTable("Keyboards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A minimalist keyboard with a US QWERTY key layout for Mac computers.",
                            Discounter = true,
                            Name = "Logitech MX",
                            OfferInSeconds = 1000,
                            Price = 149.99000000000001
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "An ergonomic and sophisticated keyboard that will give you a great gaming experience.",
                            Discounter = true,
                            Name = "Forgeon Clutch 60% Switch Brown",
                            OfferInSeconds = 200,
                            Price = 99.989999999999995
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "The Logitech® K380 Bluetooth® keyboard makes any space minimalist, modern and multi-device.",
                            Discounter = false,
                            Name = "Logitech K380",
                            Price = 54.990000000000002
                        });
                });

            modelBuilder.Entity("Beca.KeyboardShop.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TotalPrice = 1000.0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Beca.KeyboardShop.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "AQAAAAEAACcQAAAAEOHE7uLvi8V2f8E62l3O9qiAYJjnHrYblLyxcwiMHp9n8adn6owD7uBPnR1ar1PoGA==",
                            UserName = "Mayo"
                        });
                });

            modelBuilder.Entity("Beca.KeyboardShop.Entities.Keyboard", b =>
                {
                    b.HasOne("Beca.KeyboardShop.Entities.Category", "Category")
                        .WithMany("Keyboards")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Beca.KeyboardShop.Entities.Order", null)
                        .WithMany("keyboards")
                        .HasForeignKey("OrderId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Beca.KeyboardShop.Entities.Order", b =>
                {
                    b.HasOne("Beca.KeyboardShop.Entities.User", "user")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Beca.KeyboardShop.Entities.Category", b =>
                {
                    b.Navigation("Keyboards");
                });

            modelBuilder.Entity("Beca.KeyboardShop.Entities.Order", b =>
                {
                    b.Navigation("keyboards");
                });
#pragma warning restore 612, 618
        }
    }
}
