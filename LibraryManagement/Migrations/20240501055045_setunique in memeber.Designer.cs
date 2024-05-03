﻿// <auto-generated />
using System;
using LibraryManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240501055045_setunique in memeber")]
    partial class setuniqueinmemeber
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryManagement.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"));

                    b.Property<string>("AuthorBio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            AuthorBio = "An emerging author with a unique voice.",
                            AuthorName = "Jane Smith"
                        },
                        new
                        {
                            AuthorId = 2,
                            AuthorBio = "Dhaka Bangladesh",
                            AuthorName = "Tanim Hasan"
                        },
                        new
                        {
                            AuthorId = 3,
                            AuthorBio = "Matijheel, Dhaka",
                            AuthorName = "Mashfiq"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("AvailableCopies")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalCopies")
                        .HasColumnType("int");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            AuthorId = 1,
                            AvailableCopies = 10,
                            Genre = "Fiction",
                            ISBN = "9780141182636",
                            PublicationDate = new DateTime(1969, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Great Gatsby",
                            TotalCopies = 15
                        },
                        new
                        {
                            BookId = 2,
                            AuthorId = 2,
                            AvailableCopies = 8,
                            Genre = "Fiction",
                            ISBN = "9780061120084",
                            PublicationDate = new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "To Kill a Mockingbird",
                            TotalCopies = 12
                        },
                        new
                        {
                            BookId = 3,
                            AuthorId = 2,
                            AvailableCopies = 5,
                            Genre = "Science Fiction",
                            ISBN = "9780451524935",
                            PublicationDate = new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "1984",
                            TotalCopies = 10
                        },
                        new
                        {
                            BookId = 4,
                            AuthorId = 1,
                            AvailableCopies = 7,
                            Genre = "Fiction",
                            ISBN = "9780316769488",
                            PublicationDate = new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Catcher in the Rye",
                            TotalCopies = 10
                        },
                        new
                        {
                            BookId = 5,
                            AuthorId = 1,
                            AvailableCopies = 6,
                            Genre = "Classic",
                            ISBN = "9780141439518",
                            PublicationDate = new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Pride and Prejudice",
                            TotalCopies = 8
                        },
                        new
                        {
                            BookId = 6,
                            AuthorId = 3,
                            AvailableCopies = 9,
                            Genre = "Fantasy",
                            ISBN = "9780261102217",
                            PublicationDate = new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Hobbit",
                            TotalCopies = 12
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.BorrowedBook", b =>
                {
                    b.Property<int>("BorrowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BorrowId"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("BorrowId");

                    b.HasIndex("BookId");

                    b.HasIndex("MemberId");

                    b.HasIndex("StatusId");

                    b.ToTable("BorrowedBooks");

                    b.HasData(
                        new
                        {
                            BorrowId = 1,
                            BookId = 1,
                            MemberId = 3,
                            StatusId = 1
                        },
                        new
                        {
                            BorrowId = 2,
                            BookId = 2,
                            MemberId = 1,
                            ReturnDate = new DateTime(2023, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StatusId = 2
                        },
                        new
                        {
                            BorrowId = 3,
                            BookId = 3,
                            MemberId = 2,
                            StatusId = 1
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MemberId");

                    b.HasIndex("PhoneNumber", "Email")
                        .IsUnique();

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberId = 1,
                            Email = "john@example.com",
                            FirstName = "John",
                            LastName = "Doe",
                            PhoneNumber = "1234567890",
                            RegistrationDate = new DateTime(2024, 5, 1, 11, 50, 43, 771, DateTimeKind.Local).AddTicks(8855)
                        },
                        new
                        {
                            MemberId = 2,
                            Email = "jane@example.com",
                            FirstName = "Jane",
                            LastName = "Smith",
                            PhoneNumber = "9876543210",
                            RegistrationDate = new DateTime(2024, 5, 1, 11, 50, 43, 771, DateTimeKind.Local).AddTicks(8858)
                        },
                        new
                        {
                            MemberId = 3,
                            Email = "alice@example.com",
                            FirstName = "Alice",
                            LastName = "Johnson",
                            PhoneNumber = "5555555555",
                            RegistrationDate = new DateTime(2024, 5, 1, 11, 50, 43, 771, DateTimeKind.Local).AddTicks(8860)
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Borrowed"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Returned"
                        });
                });

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.HasOne("LibraryManagement.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("LibraryManagement.Models.BorrowedBook", b =>
                {
                    b.HasOne("LibraryManagement.Models.Book", "Book")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.Member", "Member")
                        .WithMany("BorrowedBooks")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibraryManagement.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("LibraryManagement.Models.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("LibraryManagement.Models.Book", b =>
                {
                    b.Navigation("BorrowedBooks");
                });

            modelBuilder.Entity("LibraryManagement.Models.Member", b =>
                {
                    b.Navigation("BorrowedBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
