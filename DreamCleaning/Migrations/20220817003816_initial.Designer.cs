﻿// <auto-generated />
using System;
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
    [Migration("20220817003816_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
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
                            Password = new byte[] { 6, 148, 243, 247, 63, 195, 195, 85, 171, 22, 154, 35, 6, 0, 228, 63, 76, 131, 97, 226, 109, 220, 0, 22, 84, 202, 252, 24, 179, 59, 78, 117, 105, 129, 221, 155, 207, 27, 92, 193, 209, 171, 27, 22, 65, 224, 253, 165, 208, 201, 145, 55, 19, 105, 60, 224, 163, 53, 220, 148, 138, 30, 235, 220, 51, 203, 187, 145, 47, 157, 228, 17, 98, 98, 234, 106, 18, 51, 2, 162, 95, 217, 209, 235, 103, 169, 129, 99, 137, 230, 212, 194, 77, 97, 157, 232, 219, 96, 211, 167, 149, 3, 18, 41, 80, 150, 221, 148, 114, 249, 198, 189, 0, 79, 228, 75, 65, 40, 174, 58, 216, 6, 83, 42, 16, 93, 178, 177, 96, 166, 210, 2, 153, 28, 122, 99, 86, 138, 141, 34, 50, 198, 39, 45, 36, 18, 101, 192, 135, 246, 82, 64, 100, 128, 131, 45, 127, 248, 245, 193, 58, 139, 177, 170, 247, 1, 184, 176, 101, 166, 150, 113, 156, 109, 49, 207, 28, 233, 14, 235, 201, 56, 182, 81, 131, 57, 198, 240, 4, 85, 181, 44, 29, 11, 22, 234, 132, 22, 128, 187, 71, 250, 195, 181, 144, 239, 36, 249, 235, 84, 67, 169, 81, 15, 170, 134, 154, 188, 37, 74, 208, 72, 146, 87, 178, 108, 17, 37, 117, 44, 39, 148, 131, 130, 122, 180, 170, 122, 214, 19, 230, 196, 135, 210, 56, 28, 155, 219, 246, 204, 235, 44, 198, 213, 136, 28 },
                            Role = "SuperAdmin",
                            Salt = new byte[] { 71, 31, 134, 144, 32, 222, 74, 142, 143, 184, 206, 213, 246, 193, 21, 159, 185, 228, 15, 103, 44, 103, 54, 113, 237, 197, 150, 249, 115, 210, 59, 120, 124, 240, 214, 104, 118, 62, 14, 171, 112, 130, 78, 6, 221, 168, 92, 197, 93, 9, 72, 166, 36, 115, 123, 23, 79, 224, 125, 147, 124, 55, 235, 77, 42, 112, 135, 230, 31, 5, 18, 216, 172, 126, 173, 196, 213, 130, 251, 233, 157, 99, 207, 147, 112, 165, 109, 220, 99, 111, 203, 98, 129, 22, 216, 29, 108, 153, 246, 229, 220, 173, 235, 186, 8, 143, 230, 244, 203, 61, 112, 57, 153, 190, 236, 128, 48, 147, 247, 179, 89, 111, 180, 206, 79, 171, 1, 157 },
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