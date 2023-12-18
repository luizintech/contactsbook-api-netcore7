using ContactBook.Entities;

namespace ContactBook.Dtos.Contacts
{
    public class ContactDto
    {

        public ContactDto()
        {
        }

        public ContactDto(Contact contact)
        {
            this.Id = contact.Id;
            this.Name = contact.Name;
            this.CreatedAt = contact.CreatedAt;
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
