using ContactBook.Application.Interfaces;
using ContactBook.Dtos.Contacts;
using ContactBook.Dtos.SystemMessages;
using ContactBook.EFCore.Persistence.Interfaces;
using ContactBook.Infra.ApplicationHelpers;

namespace ContactBook.Application.Services
{
    public class ContactService
        : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<ContactDto>> FindAllAsync()
            => (await _contactRepository.GetAllAsync()).Select(c => c.ToDto()).ToList();

        public async Task<ContactDto> FindByIdAsync(int id)
            => new ContactDto(await _contactRepository.GetByIdAsync(id));


        public async Task<ResultDto> InsertAsync(ContactDto contactDto)
        {
            var result = new ResultDto();
            result.IdentityId = await _contactRepository.AddAsync(contactDto.ToEntity());
            return result;
        }

        public async Task<ResultDto> AmendDataAsync(ContactDto contactDto)
        {
            var result = new ResultDto();
            await _contactRepository.UpdateAsync(contactDto.ToEntity());
            result.Succeed = true;
            return result;
        }

        public async Task<ResultDto> RemoveDataAsync(int id)
        {
            var result = new ResultDto();
            await _contactRepository.DeleteAsync(id);
            result.Succeed = true;
            return result;
        }

    }
}
