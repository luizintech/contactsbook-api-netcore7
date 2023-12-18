using ContactBook.Application.Interfaces;
using ContactBook.Dtos.ContactTypes;
using ContactBook.EFCore.Persistence.Interfaces;
using ContactBook.Infra.ApplicationHelpers;

namespace ContactBook.Application.Services
{
    public class ContactTypeService
        : IContactTypeService
    {
        private readonly IContactTypeRepository _contactTypeRepository;
        public ContactTypeService(IContactTypeRepository contactTypeRepository)
        {
            _contactTypeRepository = contactTypeRepository;
        }

        public async Task<IEnumerable<ContactTypeDto>> FindAllAsync()
            => (await _contactTypeRepository.GetAllAsync()).Select(c => c.ToDto()).ToList();
    }
}
