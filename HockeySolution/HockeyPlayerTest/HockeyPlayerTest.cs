using FluentAssertions;
using Hockey.Data;

namespace HockeyTestProject
{
    public class HockeyPlayerTest
    {
        public HockeyPlayer GenerateTestPlayer()
        {
            return new HockeyPlayer();
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(1, 1);
        }

        [Fact] //A test to determine if a single fact is true
        public void AddOnePlusOne()
        {
            //Test if 1 + 1 =2
            //Arrange - Set up the values
            int a = 1;
            int b = 1;
            int actual;

            //Act 
            actual = a + b;

            //Assert
            //Xunit Syntax
            //Assert.Equal(2, actual);
            //FluentAssertions
            actual.Should().Be(2);
        }
        [Fact]
        public void HockeyPlayer_FirstName_ReturnsGoodFirstName()
        {
            //Arrange
            string actual;//result of the get property
            HockeyPlayer player = GenerateTestPlayer();//Get a hockeyplayer object
            const string NAME = "test";
            //Act
            player.FirstName = NAME;
            actual = player.FirstName;
            //Assert
            actual.Should().Be(NAME);
        }
        [Fact]
        //Test for an empty string firstname
        //Arrange
        public void HockeyPlayer_FirstName_ThrowsExceptionForEmptyArguments()
        {
            //Arrange
            HockeyPlayer player = GenerateTestPlayer();
            const string EMPTYNAME = "";

            //We want to create an Action that will run in the assertion only            
            Action act = () => player.FirstName = EMPTYNAME;

            //Assert
            act.Should().Throw<Exception>().WithMessage("First name cannot be null.");
        }
    }
}