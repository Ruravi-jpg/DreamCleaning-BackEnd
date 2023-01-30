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
    [Migration("20230112012421_workUnit")]
    partial class workUnit
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
                            Password = new byte[] { 133, 15, 59, 95, 179, 237, 191, 123, 38, 232, 70, 174, 109, 107, 20, 93, 19, 183, 18, 219, 38, 125, 49, 74, 203, 106, 102, 178, 250, 91, 38, 199, 254, 94, 67, 96, 130, 220, 69, 16, 176, 217, 226, 50, 44, 106, 18, 80, 209, 55, 102, 13, 173, 77, 193, 15, 192, 120, 6, 67, 229, 151, 117, 167, 180, 91, 237, 212, 138, 155, 77, 252, 228, 4, 149, 210, 88, 221, 242, 54, 57, 11, 9, 25, 40, 100, 34, 253, 90, 149, 120, 219, 89, 235, 227, 163, 86, 241, 72, 201, 162, 10, 246, 81, 111, 133, 88, 68, 153, 240, 135, 12, 209, 181, 221, 215, 79, 53, 152, 65, 64, 244, 75, 131, 115, 171, 171, 34, 189, 86, 26, 113, 255, 61, 32, 56, 58, 40, 207, 90, 222, 101, 13, 78, 203, 52, 78, 163, 241, 18, 172, 235, 12, 195, 17, 149, 69, 209, 237, 102, 42, 48, 106, 195, 202, 133, 235, 51, 180, 46, 201, 250, 191, 182, 255, 169, 179, 94, 60, 185, 103, 48, 186, 157, 191, 80, 32, 166, 178, 211, 45, 7, 89, 25, 69, 86, 45, 149, 251, 49, 42, 124, 16, 140, 13, 104, 238, 4, 37, 242, 100, 242, 198, 97, 38, 62, 142, 154, 35, 213, 42, 38, 199, 66, 152, 184, 226, 138, 162, 130, 10, 178, 124, 125, 69, 136, 74, 54, 7, 25, 249, 171, 113, 237, 25, 236, 106, 69, 157, 148, 235, 71, 237, 66, 136, 224 },
                            Role = "SuperAdmin",
                            Salt = new byte[] { 67, 248, 207, 29, 185, 79, 122, 126, 78, 114, 56, 99, 153, 142, 14, 24, 202, 249, 105, 35, 58, 57, 245, 239, 70, 162, 250, 13, 83, 132, 115, 180, 39, 53, 145, 140, 229, 48, 172, 239, 65, 175, 216, 5, 168, 49, 211, 242, 229, 235, 92, 151, 88, 130, 204, 19, 36, 3, 36, 209, 1, 129, 7, 225, 172, 238, 113, 204, 198, 146, 225, 194, 219, 187, 233, 153, 131, 206, 120, 16, 145, 236, 55, 148, 210, 241, 233, 164, 199, 9, 179, 9, 142, 232, 166, 105, 29, 164, 167, 50, 216, 35, 58, 99, 91, 215, 129, 215, 105, 183, 33, 138, 183, 251, 240, 194, 231, 242, 123, 251, 57, 179, 55, 150, 184, 210, 75, 240 },
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("DC.WebApi.Core.Data.Entities.WorkUnitEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("DayToWork")
                        .HasColumnType("integer");

                    b.Property<long>("EmployeeId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("PropertyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

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

                    b.Navigation("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}