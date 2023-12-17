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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactType>()
                .HasData(
                new ContactType() { Id = 1, Description = "Email", CreatedAt = DateTime.Now },
                new ContactType() { Id = 2, Description = "Phone", CreatedAt = DateTime.Now },
                new ContactType() { Id = 3, Description = "Home Phone", CreatedAt = DateTime.Now },
                new ContactType() { Id = 4, Description = "Whatsapp", CreatedAt = DateTime.Now },
                new ContactType() { Id = 5, Description = "Skype ID", CreatedAt = DateTime.Now }
            );
        }
    }
}
