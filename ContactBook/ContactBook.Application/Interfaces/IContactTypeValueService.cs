using ContactBook.Dtos.ContactTypeValues;
using ContactBook.Dtos.SystemMessages;

namespace ContactBook.Application.Interfaces
{
    public interface IContactTypeValueService
    {
        Task<ResultDto> AmendDataAsync(ContactTypeValueDto contactTypeValueDto);
        Task<IEnumerable<ContactTypeValueDto>> FindAllAsync();
        Task<ContactTypeValueDto> FindByIdAsync(int id);
        Task<ResultDto> InsertAsync(ContactTypeValueDto contactTypeValueDto);
        Task<ResultDto> RemoveDataAsync(int id);
    }
}
