using ContactBook.Entities;

namespace ContactBook.EFCore.Persistence.Interfaces
{
    public interface IContactTypeValueReporitory
    {
        Task<IEnumerable<ContactTypeValue>> GetAllAsync();
        Task<ContactTypeValue> GetByIdAsync(int id);
        Task<int> AddAsync(ContactTypeValue contactTypeValue);
        Task<bool> DeleteAsync(int id);
        Task UpdateAsync(ContactTypeValue contactTypeValue);
    }
}
