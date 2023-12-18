using ContactBook.Dtos.Contacts;
using ContactBook.Dtos.ContactTypes;
using ContactBook.Entities;

namespace ContactBook.Dtos.ContactTypeValues
{
    public class ContactTypeValueDto
    {
        public ContactTypeValueDto()
        {
        }

        public ContactTypeValueDto(ContactTypeValue contactTypeValue)
        {
            this.Id = contactTypeValue.Id;
            this.Value = contactTypeValue.Value;
            this.ContactId = contactTypeValue.ContactId;
            this.ContactTypeId = contactTypeValue.ContactTypeId;
            this.CreatedAt = contactTypeValue.CreatedAt;
        }
        public int Id { get; set; }
        public int ContactTypeId { get; set; } = 0;
        public ContactTypeDto ContactType { get; set; } = new ContactTypeDto();
        public int ContactId { get; set; } = 0;
        public ContactDto Contact { get; set; } = new ContactDto();
        public string Value { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
