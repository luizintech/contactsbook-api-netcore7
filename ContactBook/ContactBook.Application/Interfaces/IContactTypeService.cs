using ContactBook.Dtos.ContactTypes;

namespace ContactBook.Application.Interfaces
{
    public interface IContactTypeService
    {
        Task<IEnumerable<ContactTypeDto>> FindAllAsync();
    }
}
