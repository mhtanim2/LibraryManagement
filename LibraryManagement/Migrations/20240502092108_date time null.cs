using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class datetimenull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 21, 7, 874, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 21, 7, 874, DateTimeKind.Local).AddTicks(1878));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 21, 7, 874, DateTimeKind.Local).AddTicks(1880));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 17, 11, 324, DateTimeKind.Local).AddTicks(6177));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 17, 11, 324, DateTimeKind.Local).AddTicks(6180));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 17, 11, 324, DateTimeKind.Local).AddTicks(6183));
        }
    }
}
