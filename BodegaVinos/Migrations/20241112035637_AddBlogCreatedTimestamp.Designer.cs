﻿// <auto-generated />
using System;
using BodegaVinos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BodegaVinos.Migrations
{
    [DbContext(typeof(BodegaDbContext))]
    [Migration("20241112035637_AddBlogCreatedTimestamp")]
    partial class AddBlogCreatedTimestamp
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("BodegaVinos.Data.Entities.Cata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WineId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WineId");

                    b.ToTable("Catas");
                });

            modelBuilder.Entity("BodegaVinos.Data.Entities.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CataId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CataId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("BodegaVinos.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BodegaVinos.Data.Entities.Wine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Stock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Variety")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Wines");
                });

            modelBuilder.Entity("BodegaVinos.Data.Entities.Cata", b =>
                {
                    b.HasOne("BodegaVinos.Data.Entities.Wine", "Wine")
                        .WithMany()
                        .HasForeignKey("WineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Wine");
                });

            modelBuilder.Entity("BodegaVinos.Data.Entities.Guest", b =>
                {
                    b.HasOne("BodegaVinos.Data.Entities.Cata", null)
                        .WithMany("guests")
                        .HasForeignKey("CataId");
                });

            modelBuilder.Entity("BodegaVinos.Data.Entities.Cata", b =>
                {
                    b.Navigation("guests");
                });
#pragma warning restore 612, 618
        }
    }
}
