using FluentAssertions;
using ValidationUtilities;
namespace UtilitesTestProject
{
    public class UtilitesTest
    {
        //we need to check for null,""," " and valid string
        [Fact]
        public void Utilities_IsNullOrEmptyOrWhiteSpace_ReturnsFalseForNonEmptyString()
        {
            //Arrange
            bool actual;
            const string GOOD_STRING = "X";

            //Act
            actual = Utilities.IsNullOrEmptyOrWhiteSpace(GOOD_STRING);

            //Assert
            actual.Should().BeFalse();
            //OR
            actual.Should().Be(false);
        }

        //We can use [THeory] test methods with Inline data to call the method several times with different arguments
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]

        public void Utilities_IsNullOrEmptyOrWhiteSpace_RetuensTrueForEmptyNullOrWhiteSpace(string value)
        {
            bool actual;

            actual = Utilities.IsNullOrEmptyOrWhiteSpace(value);

            actual.Should().BeTrue();
        }
    }
}