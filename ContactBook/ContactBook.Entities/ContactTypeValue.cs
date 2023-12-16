using System.ComponentModel.DataAnnotations;

namespace ContactBook.Entities
{
    public class ContactTypeValue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ContactTypeId { get; set; } = 0;
        public ContactType ContactType { get; set; } = new ContactType();

        [Required]
        public int ContactId { get; set; } = 0;
        public Contact Contact { get; set; } = new Contact();

        [Required]
        [MaxLength(50)]
        public string Value { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
