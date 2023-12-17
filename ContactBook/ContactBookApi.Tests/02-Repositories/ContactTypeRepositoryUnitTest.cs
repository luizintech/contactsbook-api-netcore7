using ContactBook.EFCore.Persistence.DataContexts;
using ContactBook.EFCore.Persistence.Repositories;
using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactBookApi.Tests._02_Repositories
{

    /// <summary>
    /// Here I used to the Martin Fowler pattern for UnitTests GivenWhenThen to identify the facts of my tests.
    /// </summary>
    public class ContactTypeRepositoryUnitTest
    {
        private readonly ContactBookDbContext _dbContext;
        public ContactTypeRepositoryUnitTest()
        {
            var options = new DbContextOptionsBuilder<ContactBookDbContext>()
                .UseInMemoryDatabase(databaseName: "fakeDatabase")
                .Options;
            _dbContext = new ContactBookDbContext(options);

            //Mock some results in memory for tests.
            _dbContext.ContactTypes.Add(new ContactType() { Id = 1, Description = "Phone", CreatedAt = DateTime.Now });
            _dbContext.ContactTypes.Add(new ContactType() { Id = 2, Description = "Email", CreatedAt = DateTime.Now });
            _dbContext.SaveChanges();
        }

        [Fact]
        public async Task GivenRepository_WhenYouNeedToFindContactTypes_ThenGiveAllTheContactTypes()
        {
            // arrange
            var repository = new ContactTypeRepository(_dbContext);

            //act
            var contactTypes = await repository.GetAllAsync();

            //assert
            Assert.NotNull(contactTypes);
            Assert.True(contactTypes.Count() > 0);
        }

    }
}
