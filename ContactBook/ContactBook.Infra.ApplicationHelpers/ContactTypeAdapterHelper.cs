using ContactBook.Dtos.ContactTypes;
using ContactBook.Entities;

namespace ContactBook.Infra.ApplicationHelpers
{
    public static class ContactTypeAdapterHelper
    {
        public static ContactTypeDto ToDto(this ContactType contactType)
        {
            return new ContactTypeDto()
            {
                Id = contactType.Id,
                Description = contactType.Description,
                CreatedAt = contactType.CreatedAt
            };
        }
    }
}
