using LibraryManagement.Data;
using LibraryManagement.Interface;
using LibraryManagement.Models;

namespace LibraryManagement.Repository
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Member entity)
        {
            _context.Members.Update(entity);
        }
    }
}

