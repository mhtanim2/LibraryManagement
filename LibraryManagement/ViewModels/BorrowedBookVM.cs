using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.ViewModels
{
    public class BorrowedBookVM
    {
        public BorrowedBook? BorrowedBook { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? StatusList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? MemberList { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem>? BookList { get; set; }

    }
}
