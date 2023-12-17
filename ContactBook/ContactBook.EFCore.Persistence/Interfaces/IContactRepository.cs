using ContactBook.Entities;

namespace ContactBook.EFCore.Persistence.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task<int> AddAsync(Contact contact);
        Task<bool> DeleteAsync(int id);
        Task UpdateAsync(Contact contact);
    }
}
