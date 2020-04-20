﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RileyBotDatabaseLibrary.Data;

namespace RileyBotDatabaseLibrary.Migrations
{
    [DbContext(typeof(RileyBotContext))]
    partial class RileyBotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("RileyBotDatabaseLibrary.Models.Drop", b =>
                {
                    b.Property<int>("DropId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("KillCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Points")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DropId");

                    b.HasIndex("UserId");

                    b.ToTable("Drops");
                });

            modelBuilder.Entity("RileyBotDatabaseLibrary.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("LinkUrl")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("LinkId");

                    b.HasIndex("UserId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("RileyBotDatabaseLibrary.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Added")
                        .HasColumnType("TEXT");

                    b.Property<ulong>("DiscordId")
                        .HasColumnType("INTEGER");

                    b.HasKey("UserId");

                    b.HasIndex("DiscordId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RileyBotDatabaseLibrary.Models.Drop", b =>
                {
                    b.HasOne("RileyBotDatabaseLibrary.Models.User", null)
                        .WithMany("Drops")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RileyBotDatabaseLibrary.Models.Link", b =>
                {
                    b.HasOne("RileyBotDatabaseLibrary.Models.User", null)
                        .WithMany("Links")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}