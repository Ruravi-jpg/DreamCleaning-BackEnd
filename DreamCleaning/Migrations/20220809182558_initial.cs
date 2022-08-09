﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DC.WebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", nullable: true),
                    Salt = table.Column<byte[]>(type: "bytea", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "Role", "Salt", "Username" },
                values: new object[] { 1L, true, new byte[] { 105, 41, 254, 36, 241, 52, 77, 214, 30, 37, 235, 134, 200, 220, 96, 51, 77, 10, 100, 132, 47, 250, 103, 154, 17, 113, 220, 131, 209, 232, 232, 148, 38, 234, 118, 203, 71, 34, 222, 199, 136, 86, 53, 16, 107, 95, 247, 148, 219, 22, 132, 13, 65, 57, 197, 60, 222, 203, 48, 45, 197, 241, 228, 239, 9, 245, 117, 72, 105, 249, 25, 51, 158, 231, 33, 142, 101, 45, 175, 27, 216, 175, 188, 198, 62, 207, 23, 101, 118, 202, 47, 121, 178, 72, 245, 103, 217, 68, 115, 235, 76, 214, 202, 55, 253, 99, 169, 95, 198, 1, 159, 98, 234, 230, 143, 251, 217, 155, 86, 200, 155, 55, 4, 87, 224, 194, 40, 231, 36, 93, 183, 148, 156, 230, 70, 178, 118, 237, 176, 29, 242, 94, 90, 194, 38, 117, 135, 146, 50, 124, 216, 2, 147, 143, 201, 214, 10, 27, 59, 38, 227, 85, 183, 195, 205, 213, 251, 25, 95, 95, 41, 135, 208, 121, 127, 217, 48, 242, 236, 114, 232, 172, 66, 90, 152, 2, 36, 222, 92, 93, 209, 207, 46, 24, 68, 116, 248, 11, 41, 28, 178, 193, 75, 75, 190, 81, 96, 204, 110, 76, 191, 110, 229, 61, 43, 57, 217, 216, 243, 202, 137, 0, 143, 7, 193, 60, 15, 15, 19, 138, 61, 22, 169, 128, 34, 59, 93, 237, 55, 203, 155, 30, 202, 241, 117, 141, 115, 134, 20, 187, 100, 10, 119, 17, 147, 255 }, "SuperAdmin", new byte[] { 149, 95, 153, 146, 112, 170, 42, 155, 163, 168, 78, 46, 109, 109, 28, 185, 16, 225, 219, 236, 182, 128, 86, 191, 147, 66, 74, 5, 79, 87, 65, 211, 216, 118, 10, 64, 136, 36, 50, 235, 42, 77, 9, 95, 212, 15, 177, 76, 236, 90, 34, 127, 131, 34, 115, 21, 143, 255, 227, 99, 116, 117, 50, 49, 137, 106, 137, 135, 236, 1, 41, 254, 92, 75, 67, 202, 252, 62, 180, 56, 117, 27, 200, 70, 92, 205, 196, 172, 242, 156, 128, 76, 88, 237, 8, 15, 52, 239, 210, 139, 216, 153, 234, 1, 229, 180, 253, 220, 252, 234, 36, 232, 171, 175, 39, 235, 184, 176, 157, 235, 213, 105, 223, 149, 254, 19, 183, 34 }, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
