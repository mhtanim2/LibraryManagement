using LibraryManagement.Models;
using LibraryManagement.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace LibraryManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Author> Authors{ get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BorrowedBook>()
                 .HasOne(bb => bb.Book)
                 .WithMany(b => b.BorrowedBooks)
                 .HasForeignKey(bb => bb.BookId);

            modelBuilder.Entity<BorrowedBook>()
                .HasOne(bb => bb.Member)
                .WithMany(m => m.BorrowedBooks)
                .HasForeignKey(bb => bb.MemberId);

            modelBuilder.Entity<BorrowedBook>()
                .HasOne(bb => bb.Status)
                .WithMany()
                .HasForeignKey(bb => bb.StatusId);

            modelBuilder.Entity<Member>()
            .HasIndex(c => new { c.PhoneNumber, c.Email })
            .IsUnique();
            modelBuilder.Entity<Book>()
            .HasIndex(c => new { c.ISBN })
            .IsUnique(true);

            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Type= SD.StatusBorrowed
                },
                new Status
                {
                    Id = 2,
                    Type = SD.StatusReturned
                });

            modelBuilder.Entity<Member>().HasData(
               new Member
               {
                   MemberId = 1,
                   PhoneNumber = "1234567890",
                   FirstName = "John",
                   LastName = "Doe",
                   Email = "john@example.com",
                   RegistrationDate = DateTime.Now
               },
               new Member
               {
                   MemberId = 2,
                   PhoneNumber = "9876543210",
                   FirstName = "Jane",
                   LastName = "Smith",
                   Email = "jane@example.com",
                   RegistrationDate = DateTime.Now
               },
               new Member
               {
                   MemberId = 3,
                   PhoneNumber = "5555555555",
                   FirstName = "Alice",
                   LastName = "Johnson",
                   Email = "alice@example.com",
                   RegistrationDate = DateTime.Now
               });

            modelBuilder.Entity<Author>().HasData(
                new Author
                {

                    AuthorId= 1,
                    AuthorName= "Jane Smith",
                    AuthorBio= "An emerging author with a unique voice."
                },
                new Author
                {
                    AuthorId = 2,
                    AuthorName = "Tanim Hasan",
                    AuthorBio = "Dhaka Bangladesh"
                },
                new Author
                {
                    AuthorId = 3,
                    AuthorName = "Mashfiq",
                    AuthorBio = "Matijheel, Dhaka"
                });
            
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                  BookId= 1,
                  Title= "The Great Gatsby",
                  ISBN= "9780141182636",
                  Genre= "Fiction",
                  PublicationDate= new DateTime(1969, 4, 11),
                  AvailableCopies= 10,
                  TotalCopies= 15,
                  AuthorId= 1,
                }, 
                new Book
                {
                    BookId = 2,
                    Title = "To Kill a Mockingbird",
                    ISBN = "9780061120084",
                    Genre = "Fiction",
                    PublicationDate = new DateTime(1960, 7, 11),
                    AvailableCopies = 8,
                    TotalCopies = 12,
                    AuthorId = 2
                },
                new Book
                {
                    BookId = 3,
                    Title = "1984",
                    ISBN = "9780451524935",
                    Genre = "Science Fiction",
                    PublicationDate = new DateTime(1949, 6, 8),
                    AvailableCopies = 5,
                    TotalCopies = 10,
                    AuthorId = 2
                },
                new Book
                {
                    BookId = 4,
                    Title = "The Catcher in the Rye",
                    ISBN = "9780316769488",
                    Genre = "Fiction",
                    PublicationDate = new DateTime(1951, 7, 16),
                    AvailableCopies = 7,
                    TotalCopies = 10,
                    AuthorId = 1
                },
                new Book
                {
                    BookId = 5,
                    Title = "Pride and Prejudice",
                    ISBN = "9780141439518",
                    Genre = "Classic",
                    PublicationDate = new DateTime(1813, 1, 28),
                    AvailableCopies = 6,
                    TotalCopies = 8,
                    AuthorId = 1
                },
                new Book
                {
                    BookId = 6,
                    Title = "The Hobbit",
                    ISBN = "9780261102217",
                    Genre = "Fantasy",
                    PublicationDate = new DateTime(1937, 9, 21),
                    AvailableCopies = 9,
                    TotalCopies = 12,
                    AuthorId = 3
                });

            modelBuilder.Entity<BorrowedBook>().HasData(
                new BorrowedBook
                {
                    BorrowId = 1,
                    BookId = 1,
                    ReturnDate = null,
                    StatusId = 1, // Borrowed
                    MemberId = 3
                },
                new BorrowedBook
                {
                    BorrowId = 2,
                    BookId = 2,
                    ReturnDate = new DateTime(2023, 4, 15),
                    StatusId = 2, // Returned
                    MemberId = 1
                },
                new BorrowedBook
                {
                    BorrowId = 3,
                    BookId = 3,
                    ReturnDate = null,
                    StatusId = 1, // Borrowed
                    MemberId = 2
                });
        }
    }
}
