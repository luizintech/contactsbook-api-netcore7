using ContactBook.Entities;

namespace ContactBookApi.Tests._01_Entities
{
    public class ContactTypeValueUnitTest
    {

        [Theory]
        [InlineData(1, 1, 1, "miguel.renan.porto-fail-testing@accor-testing-fail.com.br", false)]
        [InlineData(2, 1, 1, "miguel.renan@accor.com.br", true)]
        [InlineData(3, 1, 2, "+557926742276", true)]
        [InlineData(4, 1, 3, "+5579985751186", true)]
        public void ValidateModel(int id, int typeId, int contactId, string value, bool expected)
        {
            //Assemble
            ContactTypeValue contactTypeValue = DumpEntity(id, typeId, contactId, value);

            //Act
            bool actual = ValidateDataAnnotationsHelper.Validate(contactTypeValue);

            //Assert
            Assert.Equal(actual, expected);
        }

        private static ContactTypeValue DumpEntity(int id, int typeId, int contactId, string value)
        {
            return new ContactTypeValue()
            {
                Id = id,
                ContactTypeId = typeId,
                ContactId = contactId,  
                Value = value,
                CreatedAt = DateTime.Now
            };
        }
    }
}
