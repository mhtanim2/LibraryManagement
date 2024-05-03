using LibraryManagement.Models;

namespace LibraryManagement.Interface
{
    public interface IStatusRepository:IRepository<Status>
    {
        void Update(Status entity);
    }
}
