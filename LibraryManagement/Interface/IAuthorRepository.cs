using LibraryManagement.Models;

namespace LibraryManagement.Interface
{
    public interface IAuthorRepository:IRepository<Author>
    {
        void Update(Author entity);
    }
}
