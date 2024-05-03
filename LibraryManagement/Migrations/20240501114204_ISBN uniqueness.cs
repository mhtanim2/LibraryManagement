using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class ISBNuniqueness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 17, 42, 3, 646, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 17, 42, 3, 646, DateTimeKind.Local).AddTicks(6017));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 17, 42, 3, 646, DateTimeKind.Local).AddTicks(6020));

            migrationBuilder.CreateIndex(
                name: "IX_Books_ISBN",
                table: "Books",
                column: "ISBN",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Books_ISBN",
                table: "Books");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 17, 11, 54, 292, DateTimeKind.Local).AddTicks(6784));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 17, 11, 54, 292, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 17, 11, 54, 292, DateTimeKind.Local).AddTicks(6788));
        }
    }
}
