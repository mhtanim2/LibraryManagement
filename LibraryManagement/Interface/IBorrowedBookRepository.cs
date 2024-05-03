using LibraryManagement.Models;

namespace LibraryManagement.Interface
{
    public interface IBorrowedBookRepository:IRepository<BorrowedBook>
    {
        void Update(BorrowedBook entity);
    }
}
