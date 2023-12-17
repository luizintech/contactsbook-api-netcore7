using ContactBook.EFCore.Persistence.DataContexts;
using ContactBook.EFCore.Persistence.Repositories;
using ContactBook.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security;

namespace ContactBookApi.Tests._02_Repositories
{
    public class ContactTypeValueRepositoryUnitTest
    {
        private readonly ContactBookDbContext _dbContext;
        public ContactTypeValueRepositoryUnitTest()
        {
            var options = new DbContextOptionsBuilder<ContactBookDbContext>()
                .UseInMemoryDatabase(databaseName: "fakeDatabase")
                .Options;
            _dbContext = new ContactBookDbContext(options);
        }

        [Fact]
        public async Task GivenRepository_WhenYouNeedToFindContactTypeValues_ThenGiveAllTheContactTypeValues()
        {
            // arrange
            var repository = new ContactTypeValueReporitory(_dbContext);

            //Mock some results in memory for tests.
            _dbContext.ContactTypeValues.Add(new ContactTypeValue() { Id = 876, Value = "mail@mail.com", CreatedAt = DateTime.Now });
            _dbContext.SaveChanges();

            //act
            var contactTypeValues = await repository.GetAllAsync();

            //assert
            Assert.NotNull(contactTypeValues);
            Assert.True(contactTypeValues.Count() > 0);
        }

        [Fact]
        public async Task GivenRepository_WhenYouNeedToFindOneContact_ThenGiveTheContact()
        {
            // arrange
            var repository = new ContactTypeValueReporitory(_dbContext);

            //Mock some results in memory for tests.
            var contactTypeValue = new ContactTypeValue() { Value = "mail2@mail.com", CreatedAt = DateTime.Now, ContactId = 1, ContactTypeId = 1 };
            _dbContext.ContactTypeValues.Add(contactTypeValue);
            _dbContext.SaveChanges();

            //act
            var contactTypeValueSearch = await repository.GetByIdAsync(contactTypeValue.Id);

            //assert
            Assert.NotNull(contactTypeValueSearch);
        }

        [Fact]
        public async Task GivenRepository_WhenYouNeedToAddContact_ThenActAndRemoveThem()
        {
            // arrange
            var repository = new ContactTypeValueReporitory(_dbContext);
            var contactTypeValue = new ContactTypeValue() { Value = "mail3@mail.co" };

            //act
            var insertedId = await repository.AddAsync(contactTypeValue);

            //assert
            Assert.True(insertedId > 0);

            var result = await repository.DeleteAsync(insertedId);
            Assert.True(result);
        }

        [Fact]
        public async Task GivenRepository_WhenYouNeedToUpdateContact_ThenUpdateThem()
        {
            // arrange
            var repository = new ContactTypeValueReporitory(_dbContext);
            var dictionaryResults = new List<bool>();
            
            var contactTypeValueInsert = new ContactTypeValue() { Value = "mail3@mail.co" };
            await repository.AddAsync(contactTypeValueInsert);

            //act
            var allContacts = await repository.GetAllAsync();
            foreach (var contact in allContacts)
            {
                var originalValue = contact.Value;
                contact.Value = $"Updated {DateTime.Now}";
                await repository.UpdateAsync(contact);

                var compareContact = await repository.GetByIdAsync(contact.Id);
                dictionaryResults.Add(compareContact.Value != originalValue);
            }

            //assert
            Assert.Contains(true, dictionaryResults);
        }

    }
}
