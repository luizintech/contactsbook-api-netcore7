using ContactBook.Dtos.Contacts;
using ContactBook.Entities;

namespace ContactBook.Infra.ApplicationHelpers
{
    public static class ContactAdapterHelper
    {
        public static ContactDto ToDto(this Contact contact)
        {
            return new ContactDto()
            {
                Id = contact.Id,
                Name = contact.Name,
                CreatedAt = contact.CreatedAt
            };
        }

        public static Contact ToEntity(this ContactDto contactDto)
        {
            return new Contact()
            {
                Id = contactDto.Id,
                Name = contactDto.Name,
                CreatedAt = contactDto.CreatedAt
            };
        }
    }
}
