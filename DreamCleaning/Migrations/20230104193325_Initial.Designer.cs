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
    [Migration("20230104193325_Initial")]
    partial class Initial
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
                            Password = new byte[] { 191, 166, 191, 175, 98, 147, 63, 64, 65, 213, 15, 242, 88, 214, 102, 42, 232, 202, 207, 101, 32, 24, 247, 224, 89, 185, 218, 10, 201, 140, 215, 221, 45, 114, 248, 54, 125, 237, 24, 159, 102, 98, 246, 107, 134, 205, 5, 11, 196, 100, 253, 73, 239, 213, 30, 62, 99, 97, 249, 224, 123, 246, 3, 218, 81, 16, 19, 23, 94, 64, 229, 12, 108, 231, 226, 48, 100, 69, 87, 45, 252, 79, 46, 226, 87, 60, 95, 233, 36, 112, 53, 184, 222, 142, 86, 75, 96, 75, 199, 71, 140, 133, 7, 42, 243, 125, 45, 165, 135, 30, 226, 103, 111, 77, 181, 76, 126, 185, 46, 159, 81, 11, 130, 111, 26, 165, 32, 145, 59, 116, 9, 222, 223, 165, 106, 12, 37, 179, 254, 175, 250, 76, 124, 78, 129, 26, 230, 135, 6, 248, 231, 225, 98, 72, 144, 156, 228, 98, 36, 41, 154, 104, 211, 16, 142, 118, 142, 167, 127, 197, 17, 206, 10, 52, 55, 211, 146, 138, 134, 211, 112, 249, 184, 165, 200, 182, 149, 99, 119, 158, 61, 79, 114, 179, 251, 60, 118, 215, 228, 109, 206, 36, 30, 9, 181, 252, 178, 89, 156, 8, 7, 152, 227, 162, 166, 41, 61, 214, 16, 134, 32, 142, 243, 184, 23, 81, 116, 39, 248, 3, 55, 33, 87, 44, 238, 174, 161, 228, 36, 115, 76, 26, 235, 210, 212, 141, 27, 67, 246, 167, 68, 32, 159, 131, 0, 79 },
                            Role = "SuperAdmin",
                            Salt = new byte[] { 80, 26, 136, 111, 35, 136, 104, 177, 136, 59, 97, 48, 127, 56, 145, 8, 242, 76, 246, 33, 212, 124, 19, 10, 101, 228, 51, 198, 17, 16, 31, 255, 181, 1, 96, 7, 164, 168, 182, 76, 147, 77, 27, 112, 198, 91, 252, 209, 155, 156, 248, 2, 243, 80, 139, 189, 251, 151, 94, 220, 116, 84, 69, 55, 10, 77, 15, 7, 66, 180, 160, 22, 113, 43, 118, 187, 122, 52, 232, 212, 22, 146, 17, 127, 197, 79, 97, 184, 48, 62, 245, 41, 10, 246, 127, 49, 120, 131, 140, 142, 166, 159, 93, 221, 185, 30, 144, 208, 68, 232, 188, 192, 203, 133, 221, 188, 123, 86, 186, 10, 199, 241, 62, 193, 18, 171, 188, 16 },
                            Username = "admin"
                        });
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
#pragma warning restore 612, 618
        }
    }
}