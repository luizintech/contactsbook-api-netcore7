using ContactBook.Entities;

namespace ContactBookApi.Tests._01_Entities
{
    public class ContactTypeUnitTest
    {

        [Theory]
        [InlineData(1, "Test", true)]
        [InlineData(2, "Email", true)]
        [InlineData(3, "Phone", true)]
        [InlineData(4, "Whatsapp", true)]
        [InlineData(5, "This text will fail because it's too long. This one can't pass never!!!!!!!", false)]
        public void ValidateModel(int id, string description, bool expected)
        {
            //Assemble
            ContactType contactType = DumpEntity(id, description);

            //Act
            bool actual = ValidateDataAnnotationsHelper.Validate(contactType);

            //Assert
            Assert.Equal(actual, expected);
        }

        private static ContactType DumpEntity(int id, string description)
        {
            return new ContactType()
            {
                Id = id,
                Description = description,
                CreatedAt = DateTime.Now
            };
        }
    }
}
