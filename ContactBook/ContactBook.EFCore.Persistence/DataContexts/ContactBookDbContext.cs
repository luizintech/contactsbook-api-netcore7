using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.EFCore.Persistence.DataContexts
{
    public class ContactBookDbContext
        : DbContext
    {
        public ContactBookDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactTypeValue> ContactTypeValues { get; set; }
    }
}
