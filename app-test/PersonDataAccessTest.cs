using System;
using Xunit;
using app_lib;
using System.Collections.Generic;

namespace app_test
{
    public class PersonDataAccessTest
    {
        public PersonDataAccess DataAccess { get; set; }
        public PersonDataAccessTest()
        {
            DataAccess = new PersonDataAccess();
        }

        [Fact]
        public void AddPerson_ShouldThrowArgumentNullException_IfPersonIsNull()
        {
            // Arrange

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => DataAccess.AddPerson(null));

            // Assert
            Assert.IsType<ArgumentNullException>(ex);
        }

        [Fact]
        public void AddPerson_ShouldReturnPerson_IfPersonIsDefined()
        {
            // Arrange
            DataAccess = new PersonDataAccess();
            var person = new Person() { FirstName = "Tony", LastName = "Jid" };

            // Act
            var result = DataAccess.AddPerson(person);

            // Assert
            Assert.Equal(person, result);
        }

        [Fact]
        public void ShowNamesInCSV_ShouldThrowNullReferenceException_IfPeopleListIsNullOrEmpty()
        {
            // Arrange

            // Act
            var ex = Assert.Throws<NullReferenceException>(() => DataAccess.ConvertNamesToListStringCSV());

            // Assert
            Assert.IsType<NullReferenceException>(ex);
        }

        [Fact]
        public void ShowNamesInCSV_ShouldReturnListStringCSV()
        {
            // Arrange
            var person1 = new Person() { FirstName = "Tony", LastName = "Jid" };
            var person2 = new Person() { FirstName = "Sandy", LastName = "Jid" };
            DataAccess = new PersonDataAccess();
            DataAccess.AddPerson(person1);
            DataAccess.AddPerson(person2);

            // Act
            var result = DataAccess.ConvertNamesToListStringCSV();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count);
            Assert.All(
                result,
                item => Assert.Contains(",", item)
            );
            Assert.Collection(
                result,
                item => Assert.Equal($"{person1.FirstName},{person1.LastName}", item),
                item => Assert.Equal($"{person2.FirstName},{person2.LastName}", item)
            );
        }
    }
}