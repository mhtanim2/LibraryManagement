using LibraryManagement.Data;
using LibraryManagement.Interface;
using LibraryManagement.Models;

namespace LibraryManagement.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        private readonly ApplicationDbContext _context;

        public StatusRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Status entity)
        {
            _context.Statuses.Update(entity);
        }
    }
}
