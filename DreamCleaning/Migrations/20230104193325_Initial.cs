using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DC.WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Alias = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    BtwnStreet1 = table.Column<string>(type: "text", nullable: true),
                    BtwnStreet2 = table.Column<string>(type: "text", nullable: true),
                    HoursService = table.Column<float>(type: "real", nullable: false),
                    CostService = table.Column<float>(type: "real", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ReferencePhotosList = table.Column<List<string>>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    StreetAddress = table.Column<string>(type: "text", nullable: false),
                    RefStreet1 = table.Column<string>(type: "text", nullable: true),
                    RefStreet2 = table.Column<string>(type: "text", nullable: true),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserEntityId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "Role", "Salt", "Username" },
                values: new object[] { 1L, true, new byte[] { 191, 166, 191, 175, 98, 147, 63, 64, 65, 213, 15, 242, 88, 214, 102, 42, 232, 202, 207, 101, 32, 24, 247, 224, 89, 185, 218, 10, 201, 140, 215, 221, 45, 114, 248, 54, 125, 237, 24, 159, 102, 98, 246, 107, 134, 205, 5, 11, 196, 100, 253, 73, 239, 213, 30, 62, 99, 97, 249, 224, 123, 246, 3, 218, 81, 16, 19, 23, 94, 64, 229, 12, 108, 231, 226, 48, 100, 69, 87, 45, 252, 79, 46, 226, 87, 60, 95, 233, 36, 112, 53, 184, 222, 142, 86, 75, 96, 75, 199, 71, 140, 133, 7, 42, 243, 125, 45, 165, 135, 30, 226, 103, 111, 77, 181, 76, 126, 185, 46, 159, 81, 11, 130, 111, 26, 165, 32, 145, 59, 116, 9, 222, 223, 165, 106, 12, 37, 179, 254, 175, 250, 76, 124, 78, 129, 26, 230, 135, 6, 248, 231, 225, 98, 72, 144, 156, 228, 98, 36, 41, 154, 104, 211, 16, 142, 118, 142, 167, 127, 197, 17, 206, 10, 52, 55, 211, 146, 138, 134, 211, 112, 249, 184, 165, 200, 182, 149, 99, 119, 158, 61, 79, 114, 179, 251, 60, 118, 215, 228, 109, 206, 36, 30, 9, 181, 252, 178, 89, 156, 8, 7, 152, 227, 162, 166, 41, 61, 214, 16, 134, 32, 142, 243, 184, 23, 81, 116, 39, 248, 3, 55, 33, 87, 44, 238, 174, 161, 228, 36, 115, 76, 26, 235, 210, 212, 141, 27, 67, 246, 167, 68, 32, 159, 131, 0, 79 }, "SuperAdmin", new byte[] { 80, 26, 136, 111, 35, 136, 104, 177, 136, 59, 97, 48, 127, 56, 145, 8, 242, 76, 246, 33, 212, 124, 19, 10, 101, 228, 51, 198, 17, 16, 31, 255, 181, 1, 96, 7, 164, 168, 182, 76, 147, 77, 27, 112, 198, 91, 252, 209, 155, 156, 248, 2, 243, 80, 139, 189, 251, 151, 94, 220, 116, 84, 69, 55, 10, 77, 15, 7, 66, 180, 160, 22, 113, 43, 118, 187, 122, 52, 232, 212, 22, 146, 17, 127, 197, 79, 97, 184, 48, 62, 245, 41, 10, 246, 127, 49, 120, 131, 140, 142, 166, 159, 93, 221, 185, 30, 144, 208, 68, 232, 188, 192, 203, 133, 221, 188, 123, 86, 186, 10, 199, 241, 62, 193, 18, 171, 188, 16 }, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Name_LastName",
                table: "Employees",
                columns: new[] { "Name", "LastName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserEntityId",
                table: "Employees",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Alias",
                table: "Properties",
                column: "Alias",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
