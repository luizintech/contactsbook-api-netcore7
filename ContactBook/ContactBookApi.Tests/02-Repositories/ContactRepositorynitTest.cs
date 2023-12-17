using ContactBook.EFCore.Persistence.DataContexts;
using ContactBook.EFCore.Persistence.Repositories;
using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace ContactBookApi.Tests._02_Repositories
{
    public class ContactRepositorynitTest
    {
        private readonly ContactBookDbContext _dbContext;
        public ContactRepositorynitTest()
        {
            var options = new DbContextOptionsBuilder<ContactBookDbContext>()
                .UseInMemoryDatabase(databaseName: "fakeDatabase")
                .Options;
            _dbContext = new ContactBookDbContext(options);
        }

        [Fact]
        public async Task GivenRepository_WhenYouNeedToFindContacts_ThenGiveAllTheContacts()
        {
            // arrange
            var repository = new ContactRepository(_dbContext);

            //Mock some results in memory for tests.
            _dbContext.Contacts.Add(new Contact() { Id = 101, Name = "Anna", CreatedAt = DateTime.Now });
            _dbContext.Contacts.Add(new Contact() { Id = 102, Name = "Jane", CreatedAt = DateTime.Now });
            _dbContext.SaveChanges();

            //act
            var contacts = await repository.GetAllAsync();

            //assert
            Assert.NotNull(contacts);
            Assert.True(contacts.Count() > 0);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(20, false)]
        public async Task GivenRepository_WhenYouNeedToFindOneContact_ThenGiveTheContact(int id, bool result)
        {
            // arrange
            var repository = new ContactRepository(_dbContext);

            //Mock some results in memory for tests.
            _dbContext.Contacts.Add(new Contact() { Id = _dbContext.Contacts.Count() + 1, Name = "John", CreatedAt = DateTime.Now });
            _dbContext.Contacts.Add(new Contact() { Id = _dbContext.Contacts.Count() + 2, Name = "Keity", CreatedAt = DateTime.Now });
            _dbContext.SaveChanges();

            //act
            var contact = await repository.GetByIdAsync(id);

            //assert
            Assert.Equal(contact != null, result);
        }

        [Fact]
        public async Task GivenRepository_WhenYouNeedToAddContact_ThenActAndRemoveThem()
        {
            // arrange
            var repository = new ContactRepository(_dbContext);
            var contact = new Contact() { Name = "Melissa" };

            //act
            var insertedId = await repository.AddAsync(contact);

            //assert
            Assert.True(insertedId > 0);

            var result = await repository.DeleteAsync(insertedId);
            Assert.True(result);
        }

        [Fact]
        public async Task GivenRepository_WhenYouNeedToUpdateContact_ThenUpdateThem()
        {
            // arrange
            var repository = new ContactRepository(_dbContext);
            var dictionaryResults = new List<bool>();
            
            var contactInsert = new Contact() { Name = "Mel Gibson" };
            await repository.AddAsync(contactInsert);

            //act
            var allContacts = await repository.GetAllAsync();
            foreach (var contact in allContacts)
            {
                var originalName = contact.Name;
                contact.Name = $"Updated {DateTime.Now}";
                await repository.UpdateAsync(contact);

                var compareContact = await repository.GetByIdAsync(contact.Id);
                dictionaryResults.Add(compareContact.Name != originalName);
            }

            //assert
            Assert.Contains(true, dictionaryResults);
        }

    }
}
