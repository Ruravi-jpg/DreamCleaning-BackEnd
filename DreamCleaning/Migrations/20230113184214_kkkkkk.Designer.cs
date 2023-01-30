﻿// <auto-generated />
using System;
using System.Collections.Generic;
using DC.WebApi.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DC.WebApi.Migrations
{
    [DbContext(typeof(DCDbContext))]
    [Migration("20230113184214_kkkkkk")]
    partial class kkkkkk
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DC.WebApi.Core.Data.Entities.EmployeeEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RefStreet1")
                        .HasColumnType("text");

                    b.Property<string>("RefStreet2")
                        .HasColumnType("text");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.HasIndex("Name", "LastName")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DC.WebApi.Core.Data.Entities.PropertyEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("BtwnStreet1")
                        .HasColumnType("text");

                    b.Property<string>("BtwnStreet2")
                        .HasColumnType("text");

                    b.Property<string>("Comments")
                        .HasColumnType("text");

                    b.Property<float>("CostService")
                        .HasColumnType("real");

                    b.Property<float>("HoursService")
                        .HasColumnType("real");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<List<string>>("ReferencePhotosList")
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.HasIndex("Alias")
                        .IsUnique();

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("DC.WebApi.Core.Data.Entities.UserEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<byte[]>("Password")
                        .HasColumnType("bytea");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IsActive = true,
                            Password = new byte[] { 153, 125, 232, 115, 240, 223, 162, 47, 165, 233, 110, 242, 44, 250, 190, 32, 114, 133, 41, 39, 4, 0, 249, 130, 60, 119, 132, 125, 15, 218, 252, 207, 183, 152, 131, 232, 166, 201, 214, 46, 236, 109, 180, 85, 241, 209, 243, 57, 201, 118, 90, 37, 134, 251, 42, 37, 244, 198, 175, 240, 177, 44, 222, 254, 79, 198, 149, 119, 232, 223, 252, 148, 15, 64, 35, 56, 64, 21, 186, 204, 93, 150, 211, 11, 94, 157, 79, 33, 197, 52, 172, 125, 247, 245, 208, 236, 140, 164, 139, 70, 133, 44, 141, 11, 122, 129, 237, 176, 63, 156, 245, 231, 85, 208, 160, 68, 27, 74, 8, 126, 75, 38, 97, 40, 227, 36, 67, 14, 203, 174, 84, 147, 241, 175, 129, 247, 95, 210, 74, 96, 104, 255, 161, 59, 36, 201, 196, 92, 229, 143, 220, 40, 137, 229, 103, 255, 250, 211, 151, 113, 107, 79, 17, 148, 205, 206, 187, 249, 195, 115, 143, 170, 101, 205, 167, 148, 186, 2, 198, 183, 7, 104, 221, 115, 225, 146, 8, 92, 50, 148, 174, 44, 242, 227, 204, 225, 220, 136, 23, 218, 219, 33, 203, 232, 217, 103, 197, 7, 161, 36, 137, 26, 162, 36, 108, 145, 26, 44, 15, 41, 65, 134, 59, 222, 169, 56, 39, 249, 90, 88, 143, 110, 237, 24, 148, 160, 49, 59, 254, 124, 130, 35, 92, 81, 69, 247, 223, 208, 241, 78, 86, 14, 160, 166, 204, 97 },
                            Role = "SuperAdmin",
                            Salt = new byte[] { 22, 84, 80, 26, 109, 33, 205, 56, 120, 210, 172, 85, 141, 64, 10, 89, 167, 19, 21, 244, 182, 90, 56, 18, 214, 57, 197, 18, 209, 2, 117, 11, 81, 42, 169, 168, 177, 11, 81, 227, 213, 8, 108, 220, 245, 197, 37, 223, 237, 90, 181, 55, 214, 28, 222, 69, 5, 185, 78, 61, 253, 167, 182, 130, 234, 129, 11, 8, 250, 52, 155, 139, 6, 107, 163, 67, 178, 12, 55, 120, 224, 115, 201, 224, 35, 96, 164, 110, 182, 168, 4, 94, 114, 85, 140, 34, 206, 47, 119, 107, 238, 136, 202, 218, 5, 252, 192, 150, 254, 26, 56, 140, 63, 103, 238, 190, 174, 92, 122, 10, 43, 223, 248, 80, 156, 191, 130, 137 },
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("DC.WebApi.Core.Data.Entities.WorkUnitEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("DayToWork")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("FinishTime")
                        .HasColumnType("interval");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<long?>("PropertyParentId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("interval");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PropertyParentId");

                    b.ToTable("WorkUnits");
                });

            modelBuilder.Entity("DC.WebApi.Core.Data.Entities.EmployeeEntity", b =>
                {
                    b.HasOne("DC.WebApi.Core.Data.Entities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("DC.WebApi.Core.Data.Entities.WorkUnitEntity", b =>
                {
                    b.HasOne("DC.WebApi.Core.Data.Entities.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DC.WebApi.Core.Data.Entities.PropertyEntity", "PropertyParent")
                        .WithMany("WorkList")
                        .HasForeignKey("PropertyParentId");

                    b.Navigation("Employee");

                    b.Navigation("PropertyParent");
                });

            modelBuilder.Entity("DC.WebApi.Core.Data.Entities.PropertyEntity", b =>
                {
                    b.Navigation("WorkList");
                });
#pragma warning restore 612, 618
        }
    }
}