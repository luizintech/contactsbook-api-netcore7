using System.ComponentModel.DataAnnotations;

namespace ContactBook.Entities
{
    public class ContactType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
