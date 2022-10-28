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
                    HoursService = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PropertyEmployeeEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PropertyId = table.Column<long>(type: "bigint", nullable: false),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyEmployeeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyEmployeeEntity_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropertyEmployeeEntity_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsActive", "Password", "Role", "Salt", "Username" },
                values: new object[] { 1L, true, new byte[] { 8, 13, 218, 14, 28, 23, 100, 164, 118, 210, 27, 55, 137, 220, 41, 14, 131, 242, 107, 204, 135, 95, 104, 125, 16, 84, 213, 52, 207, 79, 203, 203, 142, 252, 165, 174, 169, 162, 31, 83, 87, 121, 194, 27, 146, 15, 34, 3, 177, 191, 163, 201, 43, 130, 63, 205, 15, 133, 184, 30, 124, 243, 28, 100, 252, 51, 201, 167, 15, 95, 41, 22, 232, 181, 225, 51, 104, 177, 158, 38, 19, 64, 223, 76, 46, 119, 53, 18, 142, 66, 47, 208, 239, 184, 185, 3, 179, 49, 188, 141, 62, 123, 82, 217, 46, 72, 250, 102, 85, 161, 71, 200, 146, 155, 39, 244, 65, 221, 29, 120, 251, 17, 149, 237, 85, 247, 20, 150, 215, 134, 3, 144, 202, 186, 29, 205, 249, 98, 18, 84, 37, 172, 237, 54, 206, 219, 173, 235, 231, 57, 10, 57, 172, 126, 162, 144, 32, 95, 226, 36, 77, 71, 117, 146, 183, 160, 167, 179, 150, 209, 225, 158, 22, 76, 211, 81, 40, 230, 76, 36, 55, 78, 16, 252, 184, 215, 133, 89, 213, 46, 63, 164, 12, 148, 89, 234, 246, 210, 168, 12, 7, 21, 181, 87, 178, 213, 110, 33, 197, 221, 85, 53, 253, 29, 114, 203, 21, 2, 138, 202, 251, 94, 146, 81, 162, 252, 22, 31, 23, 245, 84, 228, 42, 200, 79, 254, 165, 223, 161, 218, 226, 59, 130, 251, 104, 222, 209, 168, 126, 39, 44, 86, 82, 242, 204, 208 }, "SuperAdmin", new byte[] { 251, 208, 177, 163, 20, 65, 67, 231, 7, 84, 29, 60, 121, 28, 189, 247, 10, 10, 64, 111, 174, 83, 168, 233, 50, 184, 117, 105, 194, 243, 242, 46, 67, 233, 219, 199, 91, 165, 55, 233, 246, 10, 42, 15, 243, 209, 151, 186, 129, 61, 104, 25, 118, 65, 47, 118, 217, 104, 79, 76, 37, 99, 59, 99, 1, 19, 251, 156, 221, 227, 125, 64, 160, 152, 218, 58, 127, 25, 93, 82, 175, 147, 57, 34, 245, 120, 32, 72, 72, 144, 221, 10, 150, 239, 116, 242, 69, 30, 179, 40, 223, 25, 148, 83, 248, 61, 152, 243, 237, 193, 101, 146, 36, 55, 199, 8, 167, 128, 159, 64, 183, 111, 148, 120, 216, 198, 214, 104 }, "admin" });

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
                name: "IX_PropertyEmployeeEntity_EmployeeId",
                table: "PropertyEmployeeEntity",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyEmployeeEntity_PropertyId",
                table: "PropertyEmployeeEntity",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyEmployeeEntity");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
