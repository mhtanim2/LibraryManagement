using LibraryManagement.Data;
using LibraryManagement.Interface;
using LibraryManagement.Models;

namespace LibraryManagement.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Book entity)
        {
            _context.Books.Update(entity);
        }

        public void UpdateAvailability(Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
