using ContactBook.Entities;

namespace ContactBook.EFCore.Persistence.Interfaces
{
    public interface IContactTypeRepository
    {
        Task<IEnumerable<ContactType>> GetAllAsync();
    }
}
