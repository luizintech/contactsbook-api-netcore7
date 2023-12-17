using ContactBook.Application.Interfaces;
using ContactBook.EFCore.Persistence.Interfaces;
using ContactBook.Entities.Dtos.ContactTypes;

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
        {
            var contactTypes = await _contactTypeRepository.GetAllAsync();
            return contactTypes.Select(c => new ContactTypeDto()
            {
                Id = c.Id,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            }).ToList();
        }
    }
}
