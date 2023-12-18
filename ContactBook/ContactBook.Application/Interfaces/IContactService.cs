using ContactBook.Dtos.Contacts;
using ContactBook.Dtos.SystemMessages;

namespace ContactBook.Application.Interfaces
{
    public interface IContactService
    {
        Task<ResultDto> AmendDataAsync(ContactDto contactDto);
        Task<IEnumerable<ContactDto>> FindAllAsync();
        Task<ContactDto> FindByIdAsync(int id);
        Task<ResultDto> InsertAsync(ContactDto contactDto);
        Task<ResultDto> RemoveDataAsync(int id);
    }
}
