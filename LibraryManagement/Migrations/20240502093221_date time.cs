using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class datetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 32, 20, 636, DateTimeKind.Local).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 32, 20, 636, DateTimeKind.Local).AddTicks(4725));

            migrationBuilder.UpdateData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 3,
                column: "RegistrationDate",
                value: new DateTime(2024, 5, 2, 15, 32, 20, 636, DateTimeKind.Local).AddTicks(4727));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PublicationDate",
                table: "Books",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
    }
}
