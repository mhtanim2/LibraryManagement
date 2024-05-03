using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.ViewModels
{
    public class BookVM
    {
        public Book? Book { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? AuthorList { get; set; }
    }
}
