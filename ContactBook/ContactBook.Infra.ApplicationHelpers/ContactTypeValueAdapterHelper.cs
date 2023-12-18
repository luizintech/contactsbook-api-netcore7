using ContactBook.Dtos.ContactTypeValues;
using ContactBook.Entities;

namespace ContactBook.Infra.ApplicationHelpers
{
    public static class ContactTypeValueAdapterHelper
    {
        public static ContactTypeValueDto ToDto(this ContactTypeValue contactTypeValue)
        {
            return new ContactTypeValueDto()
            {
                Id = contactTypeValue.Id,
                Value = contactTypeValue.Value,
                ContactId = contactTypeValue.ContactId,
                ContactTypeId = contactTypeValue.ContactTypeId,
                CreatedAt = contactTypeValue.CreatedAt
            };
        }

        public static ContactTypeValue ToEntity(this ContactTypeValueDto contactTypeValue)
        {
            return new ContactTypeValue()
            {
                Id = contactTypeValue.Id,
                Value = contactTypeValue.Value,
                ContactId = contactTypeValue.ContactId,
                ContactTypeId = contactTypeValue.ContactTypeId,
                CreatedAt = contactTypeValue.CreatedAt
            };
        }
    }
}
