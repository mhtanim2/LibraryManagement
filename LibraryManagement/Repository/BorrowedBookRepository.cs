using LibraryManagement.Data;
using LibraryManagement.Interface;
using LibraryManagement.Models;

namespace LibraryManagement.Repository
{
    public class BorrowedBookRepository : Repository<BorrowedBook>, IBorrowedBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BorrowedBookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(BorrowedBook entity)
        {
            _context.BorrowedBooks.Update(entity);
        }
    }
}
