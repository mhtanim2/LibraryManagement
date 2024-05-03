using LibraryManagement.Models;

namespace LibraryManagement.Interface
{
    public interface IBookRepository:IRepository<Book>
    {
        void Update(Book entity);
        void UpdateAvailability(Book entity);
    }
}
