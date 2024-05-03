using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class setuniqueinmemeber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 11, 50, 43, 771, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 11, 50, 43, 771, DateTimeKind.Local).AddTicks(8858));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 1, 11, 50, 43, 771, DateTimeKind.Local).AddTicks(8860));

            migrationBuilder.CreateIndex(
                name: "IX_Members_PhoneNumber_Email",
                table: "Members",
                columns: new[] { "PhoneNumber", "Email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Members_PhoneNumber_Email",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 4, 29, 14, 22, 29, 402, DateTimeKind.Local).AddTicks(7249));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 4, 29, 14, 22, 29, 402, DateTimeKind.Local).AddTicks(7252));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 4, 29, 14, 22, 29, 402, DateTimeKind.Local).AddTicks(7254));
        }
    }
}
