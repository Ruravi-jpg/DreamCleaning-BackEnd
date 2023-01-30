using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DC.WebApi.Migrations
{
    public partial class kkk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkUnits_Properties_PropertyEntityId",
                table: "WorkUnits");

            migrationBuilder.RenameColumn(
                name: "PropertyEntityId",
                table: "WorkUnits",
                newName: "PropertyParentId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkUnits_PropertyEntityId",
                table: "WorkUnits",
                newName: "IX_WorkUnits_PropertyParentId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 56, 73, 254, 157, 25, 151, 247, 106, 38, 104, 223, 21, 224, 240, 23, 116, 67, 17, 231, 70, 28, 156, 77, 60, 136, 121, 152, 244, 150, 220, 105, 84, 219, 14, 15, 244, 110, 188, 195, 181, 88, 81, 159, 170, 194, 171, 179, 21, 208, 49, 99, 117, 118, 169, 222, 51, 93, 156, 141, 47, 82, 133, 163, 200, 69, 208, 137, 137, 139, 71, 178, 97, 55, 29, 5, 196, 88, 238, 142, 7, 146, 160, 1, 122, 67, 102, 44, 13, 184, 229, 35, 207, 9, 159, 81, 136, 194, 109, 39, 22, 133, 60, 98, 128, 72, 152, 139, 237, 30, 63, 205, 189, 162, 172, 179, 125, 144, 112, 75, 9, 1, 34, 198, 211, 220, 168, 61, 160, 120, 3, 62, 170, 214, 155, 237, 181, 75, 214, 243, 56, 67, 164, 32, 238, 11, 183, 123, 110, 226, 64, 87, 38, 238, 0, 239, 67, 240, 186, 122, 146, 34, 205, 175, 7, 151, 82, 146, 222, 99, 148, 148, 13, 204, 14, 253, 131, 210, 116, 60, 178, 114, 135, 59, 234, 218, 142, 23, 171, 206, 118, 103, 165, 233, 132, 103, 86, 22, 61, 98, 6, 188, 120, 243, 15, 178, 140, 231, 232, 231, 225, 150, 225, 20, 36, 76, 197, 124, 54, 119, 21, 34, 103, 42, 161, 166, 242, 118, 122, 0, 102, 161, 69, 39, 48, 232, 54, 220, 3, 239, 170, 177, 66, 232, 91, 205, 195, 149, 36, 115, 87, 107, 95, 148, 217, 33, 54 }, new byte[] { 153, 109, 45, 4, 130, 126, 204, 82, 166, 49, 131, 50, 8, 205, 89, 29, 123, 157, 233, 221, 169, 231, 39, 239, 196, 40, 198, 29, 83, 89, 69, 215, 158, 40, 211, 186, 41, 215, 68, 117, 243, 109, 155, 122, 225, 72, 107, 90, 74, 84, 170, 48, 93, 5, 62, 49, 208, 177, 109, 25, 189, 67, 75, 60, 47, 252, 164, 143, 83, 43, 106, 245, 187, 147, 75, 91, 204, 254, 177, 126, 105, 15, 213, 169, 97, 17, 34, 31, 72, 242, 157, 90, 23, 55, 119, 90, 108, 76, 130, 122, 114, 193, 44, 140, 10, 215, 145, 51, 188, 85, 20, 75, 163, 202, 14, 116, 151, 216, 205, 2, 108, 60, 117, 83, 22, 155, 60, 7 } });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkUnits_Properties_PropertyParentId",
                table: "WorkUnits",
                column: "PropertyParentId",
                principalTable: "Properties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkUnits_Properties_PropertyParentId",
                table: "WorkUnits");

            migrationBuilder.RenameColumn(
                name: "PropertyParentId",
                table: "WorkUnits",
                newName: "PropertyEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkUnits_PropertyParentId",
                table: "WorkUnits",
                newName: "IX_WorkUnits_PropertyEntityId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 63, 181, 67, 48, 175, 105, 112, 62, 184, 32, 104, 89, 232, 180, 205, 64, 248, 30, 55, 18, 35, 226, 134, 108, 219, 119, 154, 24, 245, 139, 156, 245, 56, 62, 54, 61, 129, 242, 196, 171, 148, 17, 121, 93, 90, 154, 176, 246, 231, 230, 116, 71, 43, 81, 231, 190, 228, 40, 246, 241, 251, 189, 225, 30, 190, 26, 27, 246, 209, 244, 139, 15, 107, 129, 151, 89, 194, 159, 131, 175, 34, 182, 47, 45, 36, 131, 180, 82, 127, 167, 5, 174, 157, 126, 52, 118, 246, 71, 167, 141, 173, 113, 59, 146, 207, 184, 75, 120, 6, 98, 53, 211, 173, 20, 5, 165, 81, 51, 63, 172, 41, 207, 138, 159, 198, 42, 133, 211, 229, 48, 197, 245, 110, 96, 174, 102, 119, 71, 55, 150, 4, 144, 13, 21, 55, 176, 167, 242, 121, 69, 232, 26, 234, 45, 116, 245, 202, 69, 124, 32, 16, 165, 206, 231, 232, 189, 34, 119, 230, 244, 177, 70, 75, 104, 237, 131, 121, 132, 69, 247, 36, 50, 23, 82, 172, 21, 33, 71, 171, 188, 97, 0, 218, 162, 12, 67, 2, 150, 78, 110, 154, 119, 255, 207, 129, 160, 205, 153, 140, 47, 64, 216, 210, 180, 144, 194, 71, 104, 56, 142, 198, 134, 3, 165, 161, 161, 114, 50, 123, 8, 214, 135, 194, 201, 13, 186, 250, 212, 160, 153, 120, 42, 72, 0, 143, 200, 210, 110, 171, 182, 101, 211, 90, 235, 252, 245 }, new byte[] { 41, 254, 84, 189, 180, 164, 81, 98, 207, 74, 226, 190, 119, 202, 251, 211, 24, 225, 172, 49, 112, 230, 118, 109, 175, 93, 69, 156, 173, 185, 69, 161, 217, 128, 212, 108, 159, 53, 78, 251, 79, 19, 167, 72, 11, 64, 199, 253, 124, 192, 147, 224, 84, 96, 174, 191, 66, 42, 178, 16, 176, 86, 79, 226, 118, 9, 121, 234, 181, 53, 163, 48, 75, 169, 222, 109, 68, 211, 187, 229, 119, 52, 168, 134, 198, 198, 4, 214, 88, 160, 183, 86, 31, 32, 112, 103, 229, 34, 187, 142, 29, 228, 96, 3, 173, 8, 205, 41, 6, 229, 11, 67, 179, 215, 209, 147, 115, 112, 99, 98, 111, 38, 182, 151, 41, 71, 71, 125 } });

            migrationBuilder.AddForeignKey(
                name: "FK_WorkUnits_Properties_PropertyEntityId",
                table: "WorkUnits",
                column: "PropertyEntityId",
                principalTable: "Properties",
                principalColumn: "Id");
        }
    }
}
