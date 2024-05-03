using LibraryManagement.Data;
using LibraryManagement.Interface;
using LibraryManagement.Models;

namespace LibraryManagement.Repository
{
    
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Author entity)
        {
            _context.Authors.Update(entity);
        }
    }
}
