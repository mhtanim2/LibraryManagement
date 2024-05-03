using LibraryManagement.Models;

namespace LibraryManagement.Interface
{
    public interface IMemberRepository:IRepository<Member>
    {
        void Update(Member entity);

    }
}
