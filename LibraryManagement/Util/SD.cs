using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.Util
{
    public static class SD
    {

        public const string Role_Admin = "Admin";
        public const string Author = "Author";
        public const string Book = "Book";
        public const string Member = "Member";
        public const string Status = "Status";
        // Status
        public const string StatusBorrowed = "Borrowed";
        public const string StatusReturned = "Returned";
        
        public static char[] stringSplit = new char[] { ',' };
        
        public static async Task<List<SelectListItem>> GetItemListAsync<T>(IEnumerable<T> items, Func<T, string> textSelector, Func<T, string> valueSelector)
        {
            return items.Select(a => new SelectListItem
            {
                Text = textSelector(a),
                Value = valueSelector(a)
            }).ToList();
        }
    }
}
