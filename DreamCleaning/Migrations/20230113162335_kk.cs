using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DC.WebApi.Migrations
{
    public partial class kk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkUnits_Properties_PropertyId",
                table: "WorkUnits");

            migrationBuilder.DropIndex(
                name: "IX_WorkUnits_PropertyId",
                table: "WorkUnits");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "WorkUnits");

            migrationBuilder.AddColumn<long>(
                name: "PropertyEntityId",
                table: "WorkUnits",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 63, 181, 67, 48, 175, 105, 112, 62, 184, 32, 104, 89, 232, 180, 205, 64, 248, 30, 55, 18, 35, 226, 134, 108, 219, 119, 154, 24, 245, 139, 156, 245, 56, 62, 54, 61, 129, 242, 196, 171, 148, 17, 121, 93, 90, 154, 176, 246, 231, 230, 116, 71, 43, 81, 231, 190, 228, 40, 246, 241, 251, 189, 225, 30, 190, 26, 27, 246, 209, 244, 139, 15, 107, 129, 151, 89, 194, 159, 131, 175, 34, 182, 47, 45, 36, 131, 180, 82, 127, 167, 5, 174, 157, 126, 52, 118, 246, 71, 167, 141, 173, 113, 59, 146, 207, 184, 75, 120, 6, 98, 53, 211, 173, 20, 5, 165, 81, 51, 63, 172, 41, 207, 138, 159, 198, 42, 133, 211, 229, 48, 197, 245, 110, 96, 174, 102, 119, 71, 55, 150, 4, 144, 13, 21, 55, 176, 167, 242, 121, 69, 232, 26, 234, 45, 116, 245, 202, 69, 124, 32, 16, 165, 206, 231, 232, 189, 34, 119, 230, 244, 177, 70, 75, 104, 237, 131, 121, 132, 69, 247, 36, 50, 23, 82, 172, 21, 33, 71, 171, 188, 97, 0, 218, 162, 12, 67, 2, 150, 78, 110, 154, 119, 255, 207, 129, 160, 205, 153, 140, 47, 64, 216, 210, 180, 144, 194, 71, 104, 56, 142, 198, 134, 3, 165, 161, 161, 114, 50, 123, 8, 214, 135, 194, 201, 13, 186, 250, 212, 160, 153, 120, 42, 72, 0, 143, 200, 210, 110, 171, 182, 101, 211, 90, 235, 252, 245 }, new byte[] { 41, 254, 84, 189, 180, 164, 81, 98, 207, 74, 226, 190, 119, 202, 251, 211, 24, 225, 172, 49, 112, 230, 118, 109, 175, 93, 69, 156, 173, 185, 69, 161, 217, 128, 212, 108, 159, 53, 78, 251, 79, 19, 167, 72, 11, 64, 199, 253, 124, 192, 147, 224, 84, 96, 174, 191, 66, 42, 178, 16, 176, 86, 79, 226, 118, 9, 121, 234, 181, 53, 163, 48, 75, 169, 222, 109, 68, 211, 187, 229, 119, 52, 168, 134, 198, 198, 4, 214, 88, 160, 183, 86, 31, 32, 112, 103, 229, 34, 187, 142, 29, 228, 96, 3, 173, 8, 205, 41, 6, 229, 11, 67, 179, 215, 209, 147, 115, 112, 99, 98, 111, 38, 182, 151, 41, 71, 71, 125 } });

            migrationBuilder.CreateIndex(
                name: "IX_WorkUnits_PropertyEntityId",
                table: "WorkUnits",
                column: "PropertyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkUnits_Properties_PropertyEntityId",
                table: "WorkUnits",
                column: "PropertyEntityId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkUnits_Properties_PropertyEntityId",
                table: "WorkUnits");

            migrationBuilder.DropIndex(
                name: "IX_WorkUnits_PropertyEntityId",
                table: "WorkUnits");

            migrationBuilder.DropColumn(
                name: "PropertyEntityId",
                table: "WorkUnits");

            migrationBuilder.AddColumn<long>(
                name: "PropertyId",
                table: "WorkUnits",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 118, 65, 252, 72, 244, 65, 239, 7, 106, 71, 43, 12, 224, 121, 97, 181, 36, 80, 23, 1, 245, 54, 115, 32, 126, 252, 161, 244, 228, 199, 129, 78, 186, 85, 220, 123, 225, 253, 7, 221, 41, 223, 17, 22, 174, 238, 206, 98, 244, 182, 211, 109, 249, 202, 125, 125, 62, 103, 101, 222, 60, 136, 129, 216, 183, 222, 181, 97, 115, 19, 210, 112, 173, 137, 160, 200, 161, 148, 216, 154, 171, 37, 38, 13, 100, 30, 219, 0, 122, 121, 215, 28, 140, 21, 214, 29, 250, 73, 79, 92, 107, 39, 248, 110, 213, 6, 99, 94, 182, 105, 174, 67, 250, 211, 225, 165, 96, 172, 249, 124, 42, 247, 33, 193, 67, 94, 21, 157, 75, 31, 44, 208, 225, 157, 243, 225, 137, 118, 147, 162, 25, 113, 11, 205, 101, 20, 234, 242, 199, 97, 17, 13, 70, 101, 157, 170, 68, 182, 147, 167, 60, 72, 142, 151, 194, 220, 152, 240, 252, 72, 179, 111, 40, 76, 67, 157, 244, 245, 52, 229, 47, 72, 161, 160, 145, 91, 31, 249, 110, 20, 210, 117, 118, 223, 174, 151, 129, 154, 188, 54, 94, 44, 126, 134, 106, 168, 206, 169, 55, 4, 111, 179, 179, 250, 102, 65, 171, 102, 89, 237, 190, 171, 248, 161, 122, 33, 31, 148, 106, 50, 30, 125, 152, 181, 92, 146, 200, 42, 248, 154, 254, 135, 253, 182, 182, 97, 227, 90, 92, 203, 226, 124, 205, 90, 140, 220 }, new byte[] { 219, 86, 152, 95, 176, 41, 6, 137, 65, 236, 45, 36, 181, 114, 126, 105, 212, 93, 36, 9, 183, 42, 59, 178, 154, 240, 224, 63, 67, 248, 77, 186, 240, 155, 163, 49, 183, 237, 138, 160, 28, 192, 70, 174, 255, 125, 185, 110, 172, 229, 162, 252, 50, 181, 71, 84, 162, 224, 226, 81, 120, 245, 85, 40, 168, 7, 209, 168, 47, 114, 204, 39, 184, 74, 159, 38, 117, 166, 220, 54, 255, 173, 190, 140, 157, 158, 63, 76, 135, 97, 69, 249, 98, 21, 69, 37, 134, 231, 174, 243, 112, 148, 90, 223, 246, 34, 37, 175, 4, 33, 125, 86, 81, 217, 106, 223, 211, 104, 68, 122, 170, 179, 240, 63, 135, 56, 198, 253 } });

            migrationBuilder.CreateIndex(
                name: "IX_WorkUnits_PropertyId",
                table: "WorkUnits",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkUnits_Properties_PropertyId",
                table: "WorkUnits",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
