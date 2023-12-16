using ContactBook.Entities;

namespace ContactBookApi.Tests._01_Entities
{
    public class ContactUnitTest
    {

        [Theory]
        [InlineData(1, "Riana Aimee Benevides", true)]
        [InlineData(2, "Madalena Kataleya Canário", true)]
        [InlineData(3, "Elsa Polina Martins Carvalho Granja", false)]
        [InlineData(4, "Violeta Linhares", true)]
        [InlineData(5, "Érica Linda Anhaia Leitão Tigre", false)]
        [InlineData(6, "Pedro de Alcântara Francisco Antônio João Carlos Xavier de Paula Miguel Rafael Joaquim José Gonzaga Pascoal Cipriano Serafim de Bragança e Bourbon", false)]
        public void ValidateModel(int id, string name, bool expected)
        {
            //Assemble
            Contact contact = DumpEntity(id, name);

            //Act
            bool actual = ValidateDataAnnotationsHelper.Validate(contact);

            //Assert
            Assert.Equal(actual, expected);
        }

        private static Contact DumpEntity(int id, string name)
        {
            return new Contact()
            {
                Id = id,
                Name = name,
                CreatedAt = DateTime.Now
            };
        }
    }
}
