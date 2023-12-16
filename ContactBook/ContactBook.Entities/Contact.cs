using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<ContactTypeValue> ContactTypeValues { get; set; } = new Collection<ContactTypeValue>();
    }
}
