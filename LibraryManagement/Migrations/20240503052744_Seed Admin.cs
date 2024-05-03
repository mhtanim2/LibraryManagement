using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 3, 11, 27, 43, 639, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 3, 11, 27, 43, 639, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 3, 11, 27, 43, 639, DateTimeKind.Local).AddTicks(3030));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 3, 11, 12, 18, 40, DateTimeKind.Local).AddTicks(8265));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 3, 11, 12, 18, 40, DateTimeKind.Local).AddTicks(8268));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 3, 11, 12, 18, 40, DateTimeKind.Local).AddTicks(8270));
        }
    }
}
