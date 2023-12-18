using ContactBook.Application.Interfaces;
using ContactBook.Dtos.ContactTypeValues;
using ContactBook.Dtos.SystemMessages;
using ContactBook.EFCore.Persistence.Interfaces;
using ContactBook.Infra.ApplicationHelpers;

namespace ContactBook.Application.Services
{
    public class ContactTypeValueService
        : IContactTypeValueService
    {
        private readonly IContactTypeValueReporitory _contactTypeValueReporitory;

        public ContactTypeValueService(IContactTypeValueReporitory contactTypeValueReporitory)
        {
            _contactTypeValueReporitory = contactTypeValueReporitory;
        }

        public async Task<IEnumerable<ContactTypeValueDto>> FindAllAsync()
            => (await _contactTypeValueReporitory.GetAllAsync()).Select(c => c.ToDto()).ToList();

        public async Task<ContactTypeValueDto> FindByIdAsync(int id)
            => new ContactTypeValueDto(await _contactTypeValueReporitory.GetByIdAsync(id));


        public async Task<ResultDto> InsertAsync(ContactTypeValueDto contactTypeValueDto)
        {
            var result = new ResultDto();
            result.IdentityId = await _contactTypeValueReporitory.AddAsync(contactTypeValueDto.ToEntity());
            return result;
        }

        public async Task<ResultDto> AmendDataAsync(ContactTypeValueDto contactTypeValueDto)
        {
            var result = new ResultDto();
            await _contactTypeValueReporitory.UpdateAsync(contactTypeValueDto.ToEntity());
            result.Succeed = true;
            return result;
        }

        public async Task<ResultDto> RemoveDataAsync(int id)
        {
            var result = new ResultDto();
            await _contactTypeValueReporitory.DeleteAsync(id);
            result.Succeed = true;
            return result;
        }
    }
}
