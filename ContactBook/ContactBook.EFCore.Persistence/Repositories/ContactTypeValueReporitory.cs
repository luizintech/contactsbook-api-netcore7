using ContactBook.EFCore.Persistence.DataContexts;
using ContactBook.EFCore.Persistence.Interfaces;
using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.EFCore.Persistence.Repositories
{
    public class ContactTypeValueReporitory
        : IContactTypeValueReporitory
    {
        private readonly ContactBookDbContext _dbContext;
        public ContactTypeValueReporitory(ContactBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(ContactTypeValue contactTypeValue)
        {
            var insertedId = 0;
            await _dbContext.ContactTypeValues.AddAsync(contactTypeValue);
            await _dbContext.SaveChangesAsync();
            insertedId = contactTypeValue.Id;
            return insertedId;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = false;

            var entity = await this.GetByIdAsync(id);
            if (entity != null)
            {
                _dbContext.ContactTypeValues.Remove(entity);
                _dbContext.SaveChanges();
                deleted = true;
            }

            return deleted;
        }

        public async Task<IEnumerable<ContactTypeValue>> GetAllAsync()
        {
            return await _dbContext.ContactTypeValues
                .ToArrayAsync();
        }

        public async Task<ContactTypeValue> GetByIdAsync(int id)
        {
            return await _dbContext.ContactTypeValues
                .Where(c => c.Id == id)
                .SingleOrDefaultAsync() ?? null!;
        }

        public async Task UpdateAsync(ContactTypeValue contactTypeValue)
        {
            this._dbContext.Set<ContactTypeValue>().UpdateRange(contactTypeValue);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
