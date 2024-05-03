using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }

        /*Title,ISBN,Genre?,PublicationDate,AvailableCopies,TotalCopies,Author*/
        [Required(ErrorMessage = "ISBN is required.")]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ISBN must be a 13-digit number.")]
        public string ISBN { get; set; }

        public string? Genre { get; set; }

        [Required]
        [Display(Name = "Publication Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PublicationDate { get; set; }

        [Required(ErrorMessage = "Available copies is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Available copies must be a non-negative number.")]
        public int AvailableCopies { get; set; }

        [Required(ErrorMessage = "Total copies is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Total copies must be a non-negative number.")]
        public int TotalCopies { get; set; }

        
        [Required(ErrorMessage = "Author is required.")]
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
        [ValidateNever]
        public ICollection<BorrowedBook> BorrowedBooks { get; set; }
    }
}
