using LibraryManagement.Repository;

namespace LibraryManagement.Interface
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepo { get; }
        IMemberRepository MemberRepo { get; }
        IBookRepository BookRepo { get; }
        IBorrowedBookRepository BorrowedBookRepo { get; }
        IStatusRepository StatusRepo { get; }
        Task SaveAsync();
        Task RollbackTransactionAsync();
        Task CommitTransactionAsync();
        void BeginTransaction();
    }
}