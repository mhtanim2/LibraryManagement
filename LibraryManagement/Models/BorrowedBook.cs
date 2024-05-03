using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class BorrowedBook
    {
        [Key]
        public int BorrowId { get; set; }
        public DateTime? ReturnDate { get; set; }
        
        [Required(ErrorMessage = "Status is required.")]
        [Display(Name ="Status")]
        public int StatusId { get; set; }
        [Required(ErrorMessage = "Book is required.")]
        [Display(Name = "Books")]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Member is required.")]
        [Display(Name = "Members")]
        public int MemberId { get; set; }
        
        [ValidateNever]
        [ForeignKey("StatusId")]
        public Status Status { get; set; }
        [ValidateNever]
        [ForeignKey("BookId")]
        public Book? Book { get; set; }
        [ValidateNever]
        [ForeignKey("MemberId")]
        public Member? Member { get; set; }
    }
}
