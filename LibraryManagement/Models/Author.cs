using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(100, ErrorMessage = "Author name must not exceed 100 characters.")]
        [Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        [Display(Name = "Author Bio")]
        public string? AuthorBio { get; set; }
        // Navigation property
        [ValidateNever]
        public ICollection<Book>? Books { get; set; }
    }
}
