using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagement.Migrations
{
    /// <inheritdoc />
    public partial class initaial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorBio = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailableCopies = table.Column<int>(type: "int", nullable: false),
                    TotalCopies = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BorrowedBooks",
                columns: table => new
                {
                    BorrowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowedBooks", x => x.BorrowId);
                    table.ForeignKey(
                        name: "FK_BorrowedBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedBooks_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BorrowedBooks_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorBio", "AuthorName" },
                values: new object[,]
                {
                    { 1, "An emerging author with a unique voice.", "Jane Smith" },
                    { 2, "Dhaka Bangladesh", "Tanim Hasan" },
                    { 3, "Matijheel, Dhaka", "Mashfiq" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Email", "FirstName", "LastName", "PhoneNumber", "RegistrationDate" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John", "Doe", "1234567890", new DateTime(2024, 4, 29, 14, 22, 29, 402, DateTimeKind.Local).AddTicks(7249) },
                    { 2, "jane@example.com", "Jane", "Smith", "9876543210", new DateTime(2024, 4, 29, 14, 22, 29, 402, DateTimeKind.Local).AddTicks(7252) },
                    { 3, "alice@example.com", "Alice", "Johnson", "5555555555", new DateTime(2024, 4, 29, 14, 22, 29, 402, DateTimeKind.Local).AddTicks(7254) }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Borrowed" },
                    { 2, "Returned" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorId", "AvailableCopies", "Genre", "ISBN", "PublicationDate", "Title", "TotalCopies" },
                values: new object[,]
                {
                    { 1, 1, 10, "Fiction", "9780141182636", new DateTime(1969, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Great Gatsby", 15 },
                    { 2, 2, 8, "Fiction", "9780061120084", new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "To Kill a Mockingbird", 12 },
                    { 3, 2, 5, "Science Fiction", "9780451524935", new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "1984", 10 },
                    { 4, 1, 7, "Fiction", "9780316769488", new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Catcher in the Rye", 10 },
                    { 5, 1, 6, "Classic", "9780141439518", new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pride and Prejudice", 8 },
                    { 6, 3, 9, "Fantasy", "9780261102217", new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Hobbit", 12 }
                });

            migrationBuilder.InsertData(
                table: "BorrowedBooks",
                columns: new[] { "BorrowId", "BookId", "MemberId", "ReturnDate", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, 3, null, 1 },
                    { 2, 2, 1, new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, 2, null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_BookId",
                table: "BorrowedBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_MemberId",
                table: "BorrowedBooks",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowedBooks_StatusId",
                table: "BorrowedBooks",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowedBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
