using LibraryManagement.Data;
using LibraryManagement.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibraryManagement.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository AuthorRepo { get; private set; }
        public IMemberRepository MemberRepo { get; private set; }
        public IBookRepository BookRepo { get; private set; }
        public IBorrowedBookRepository BorrowedBookRepo { get; private set; }
        public IStatusRepository StatusRepo { get; private set; }
        public ApplicationDbContext _context { get; }

        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            AuthorRepo = new AuthorRepository(_context);
            MemberRepo = new MemberRepository(_context);
            BookRepo = new BookRepository(_context);
            BorrowedBookRepo = new BorrowedBookRepository(_context);
            StatusRepo = new StatusRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            catch
            {

            }
        }
    }
}
