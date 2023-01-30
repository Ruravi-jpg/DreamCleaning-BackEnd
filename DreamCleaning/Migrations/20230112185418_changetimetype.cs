using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DC.WebApi.Migrations
{
    public partial class changetimetype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "StartTime",
                table: "WorkUnits",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "FinishTime",
                table: "WorkUnits",
                type: "time without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WorkUnits",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 102, 153, 22, 241, 83, 5, 108, 206, 120, 218, 60, 4, 50, 193, 214, 83, 145, 218, 175, 100, 47, 144, 151, 147, 83, 252, 211, 221, 20, 231, 171, 70, 114, 241, 84, 147, 134, 50, 57, 159, 158, 93, 11, 236, 236, 88, 53, 223, 35, 42, 34, 61, 153, 119, 157, 205, 40, 146, 188, 148, 115, 41, 41, 163, 239, 128, 94, 122, 65, 48, 251, 236, 50, 165, 36, 254, 93, 49, 87, 178, 21, 75, 139, 121, 130, 90, 8, 166, 187, 48, 211, 108, 148, 59, 41, 81, 244, 241, 83, 194, 195, 103, 10, 249, 175, 38, 208, 56, 14, 36, 138, 244, 144, 152, 173, 124, 203, 105, 13, 242, 92, 102, 234, 4, 91, 188, 146, 202, 169, 215, 170, 101, 174, 177, 216, 151, 118, 129, 48, 221, 212, 191, 112, 204, 0, 228, 160, 132, 155, 178, 129, 72, 177, 71, 189, 72, 194, 131, 58, 220, 226, 152, 190, 78, 2, 156, 222, 134, 1, 39, 181, 91, 81, 144, 22, 228, 46, 53, 47, 228, 238, 64, 223, 190, 187, 97, 16, 114, 50, 27, 136, 255, 31, 162, 241, 16, 112, 183, 36, 41, 199, 196, 36, 166, 14, 92, 232, 233, 193, 250, 253, 48, 5, 219, 79, 191, 0, 233, 254, 83, 58, 176, 118, 227, 226, 113, 95, 16, 139, 121, 194, 140, 107, 123, 150, 68, 244, 125, 254, 183, 124, 195, 109, 168, 225, 162, 226, 39, 193, 58, 92, 63, 92, 19, 121, 162 }, new byte[] { 247, 35, 128, 135, 131, 251, 165, 38, 96, 63, 150, 22, 186, 205, 162, 63, 160, 228, 13, 91, 178, 192, 42, 128, 11, 8, 250, 7, 230, 35, 72, 74, 13, 96, 105, 102, 113, 139, 185, 49, 193, 102, 194, 106, 103, 220, 166, 250, 156, 162, 1, 48, 210, 166, 29, 196, 166, 199, 55, 38, 216, 19, 136, 191, 112, 91, 113, 193, 25, 46, 92, 123, 27, 253, 199, 255, 166, 172, 122, 63, 131, 108, 76, 138, 191, 5, 73, 33, 46, 173, 51, 238, 116, 40, 126, 184, 150, 37, 204, 209, 243, 84, 241, 101, 45, 196, 136, 52, 231, 230, 249, 97, 81, 231, 142, 4, 13, 174, 100, 226, 172, 79, 67, 107, 20, 178, 216, 57 } });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkUnits_Properties_PropertyId",
                table: "WorkUnits");

            migrationBuilder.DropIndex(
                name: "IX_WorkUnits_PropertyId",
                table: "WorkUnits");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WorkUnits");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "WorkUnits",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishTime",
                table: "WorkUnits",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time without time zone");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Password", "Salt" },
                values: new object[] { new byte[] { 133, 15, 59, 95, 179, 237, 191, 123, 38, 232, 70, 174, 109, 107, 20, 93, 19, 183, 18, 219, 38, 125, 49, 74, 203, 106, 102, 178, 250, 91, 38, 199, 254, 94, 67, 96, 130, 220, 69, 16, 176, 217, 226, 50, 44, 106, 18, 80, 209, 55, 102, 13, 173, 77, 193, 15, 192, 120, 6, 67, 229, 151, 117, 167, 180, 91, 237, 212, 138, 155, 77, 252, 228, 4, 149, 210, 88, 221, 242, 54, 57, 11, 9, 25, 40, 100, 34, 253, 90, 149, 120, 219, 89, 235, 227, 163, 86, 241, 72, 201, 162, 10, 246, 81, 111, 133, 88, 68, 153, 240, 135, 12, 209, 181, 221, 215, 79, 53, 152, 65, 64, 244, 75, 131, 115, 171, 171, 34, 189, 86, 26, 113, 255, 61, 32, 56, 58, 40, 207, 90, 222, 101, 13, 78, 203, 52, 78, 163, 241, 18, 172, 235, 12, 195, 17, 149, 69, 209, 237, 102, 42, 48, 106, 195, 202, 133, 235, 51, 180, 46, 201, 250, 191, 182, 255, 169, 179, 94, 60, 185, 103, 48, 186, 157, 191, 80, 32, 166, 178, 211, 45, 7, 89, 25, 69, 86, 45, 149, 251, 49, 42, 124, 16, 140, 13, 104, 238, 4, 37, 242, 100, 242, 198, 97, 38, 62, 142, 154, 35, 213, 42, 38, 199, 66, 152, 184, 226, 138, 162, 130, 10, 178, 124, 125, 69, 136, 74, 54, 7, 25, 249, 171, 113, 237, 25, 236, 106, 69, 157, 148, 235, 71, 237, 66, 136, 224 }, new byte[] { 67, 248, 207, 29, 185, 79, 122, 126, 78, 114, 56, 99, 153, 142, 14, 24, 202, 249, 105, 35, 58, 57, 245, 239, 70, 162, 250, 13, 83, 132, 115, 180, 39, 53, 145, 140, 229, 48, 172, 239, 65, 175, 216, 5, 168, 49, 211, 242, 229, 235, 92, 151, 88, 130, 204, 19, 36, 3, 36, 209, 1, 129, 7, 225, 172, 238, 113, 204, 198, 146, 225, 194, 219, 187, 233, 153, 131, 206, 120, 16, 145, 236, 55, 148, 210, 241, 233, 164, 199, 9, 179, 9, 142, 232, 166, 105, 29, 164, 167, 50, 216, 35, 58, 99, 91, 215, 129, 215, 105, 183, 33, 138, 183, 251, 240, 194, 231, 242, 123, 251, 57, 179, 55, 150, 184, 210, 75, 240 } });
        }
    }
}
