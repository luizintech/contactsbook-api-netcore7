using ContactBook.EFCore.Persistence.DataContexts;
using ContactBook.EFCore.Persistence.Interfaces;
using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.EFCore.Persistence.Repositories
{
    public class ContactRepository
        : IContactRepository
    {
        private readonly ContactBookDbContext _dbContext;
        public ContactRepository(ContactBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(Contact contact)
        {
            var insertedId = 0;
            await _dbContext.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            insertedId = contact.Id;
            return insertedId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = false;

            var entity = await this.GetByIdAsync(id);
            if (entity != null)
            {
                _dbContext.Remove(entity);
                _dbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _dbContext.Contacts
                .ToArrayAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _dbContext.Contacts
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync() ?? null!;
        }

        public async Task UpdateAsync(Contact contact)
        {
            this._dbContext.Set<Contact>().UpdateRange(contact);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
