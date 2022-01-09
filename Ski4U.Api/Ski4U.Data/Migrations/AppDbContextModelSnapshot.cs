﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ski4U.Data;

namespace Ski4U.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Ski4U.Data.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkiItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkiItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Ski4U.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Ski4U.Data.Models.SkiItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Season")
                        .HasColumnType("int");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("SkiItems");
                });

            modelBuilder.Entity("Ski4U.Data.Models.SkiItemAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkiItemId")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SkiItemId");

                    b.ToTable("SkiItemAttributes");
                });

            modelBuilder.Entity("Ski4U.Data.Models.Comment", b =>
                {
                    b.HasOne("Ski4U.Data.Models.SkiItem", "SkiItem")
                        .WithMany("Comments")
                        .HasForeignKey("SkiItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkiItem");
                });

            modelBuilder.Entity("Ski4U.Data.Models.SkiItem", b =>
                {
                    b.HasOne("Ski4U.Data.Models.Order", "Order")
                        .WithMany("SkiItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Ski4U.Data.Models.SkiItemAttribute", b =>
                {
                    b.HasOne("Ski4U.Data.Models.SkiItem", "SkiItem")
                        .WithMany("SkiItemAttributes")
                        .HasForeignKey("SkiItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkiItem");
                });

            modelBuilder.Entity("Ski4U.Data.Models.Order", b =>
                {
                    b.Navigation("SkiItems");
                });

            modelBuilder.Entity("Ski4U.Data.Models.SkiItem", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("SkiItemAttributes");
                });
#pragma warning restore 612, 618
        }
    }
}
