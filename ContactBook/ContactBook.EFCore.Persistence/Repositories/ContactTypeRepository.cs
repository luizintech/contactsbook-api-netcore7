using ContactBook.EFCore.Persistence.DataContexts;
using ContactBook.EFCore.Persistence.Interfaces;
using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBook.EFCore.Persistence.Repositories
{
    public class ContactTypeRepository
        : IContactTypeRepository
    {
        private readonly ContactBookDbContext _dbContext;

        public ContactTypeRepository(ContactBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ContactType>> GetAllAsync()
        {
            return await _dbContext.ContactTypes
                .ToArrayAsync();
        }

    }
}
