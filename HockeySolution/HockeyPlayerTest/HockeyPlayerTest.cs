using FluentAssertions;
using Hockey.Data;

namespace HockeyTestProject
{
    public class HockeyPlayerTest
    {
        const string FIRST_NAME = "Shane";
        const string LAST_NAME = "Bell";
        const string BIRTH_PLACE = "Edmonton, AB";
        const int WEIGHT_IN_POUNDS = 190;
        const int HEIGHT_IN_INCHES = 70;
        const Position PLAYER_POSITION = Position.Goalie;
        const Shot PLAYER_SHOT = Shot.Right;
        readonly DateOnly DATE_OF_BIRTH = new DateOnly(1972, 01, 20);
        const string TOSTRING_VALUE = $"{FIRST_NAME} {LAST_NAME}";
        const int JERSEYNUMBER = 5;

        public HockeyPlayer GenerateTestPlayer()
        {
            return new HockeyPlayer();
        }
        public HockeyPlayer GenerateGreedyTestPlayer()
        {
            return new HockeyPlayer(BIRTH_PLACE, DATE_OF_BIRTH, FIRST_NAME, LAST_NAME, HEIGHT_IN_INCHES, WEIGHT_IN_POUNDS, PLAYER_POSITION, PLAYER_SHOT,JERSEYNUMBER,null);
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
        //Create a JerseyNumber property test
        [Fact]
        public void HockeyPlayerJerseyNumber_GoodGetSet()
        {
            //Arrange
            HockeyPlayer player = GenerateTestPlayer();
            int actual;
            //Act
            player.JerseyNumber = JERSEYNUMBER;
            actual = player.JerseyNumber;
            //Assert
            actual.Should().Be(JERSEYNUMBER);
        }
        //good test for jerseynumber to be between 1 and 98
        [Theory]
        [InlineData(1)]
        [InlineData(98)]
        public void HockeyPlayer_JerseyNumber_GoodGetAndSet(int value)
        {
            HockeyPlayer player = GenerateGreedyTestPlayer();
            int actual;

            player.JerseyNumber = value;
            actual = player.JerseyNumber;

            actual.Should().Be(value);
        }
        //Create exception test for bad jersey number
        [Theory]
        [InlineData(0)]
        [InlineData(99)]
        public void HockeyPlayer_JerseyNumber_BadSetThrowsException(int value)
        {
            HockeyPlayer player = GenerateGreedyTestPlayer();

            Action act = () => player.JerseyNumber = value;

            act.Should().Throw<Exception>().WithMessage("Jersey Number out of range!");
        }

        [Fact]
        public void Test_Change_Jersey_Number()
        {
            //Arrange
            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, null);
            const int EXPECTED_VALUE = 20;

            //Act
            player.JerseyNumber=EXPECTED_VALUE;

            //Assert
            player.JerseyNumber.Should().Be(EXPECTED_VALUE); 
        }
        [Fact]
        public void Test_Creation_of_GreedyConstructor_No_Teams()
        {
            //Arrange
            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, null);

            //Assert
            player.Should().NotBeNull();//was it instantiated
            //Optional
            player.FirstName.Should().Be("Shane");
            player.LastName.Should().Be("Bell");
            player.NumberOfTeams.Should().Be(0); 
            player.teams.Should().BeEmpty();
        }

        [Fact]
        public void Test_Creation_of_GreedyConstructor_With_Teams()
        {
            //Arrange
            List<Team> teams = new List<Team>();
            teams.Add(new Team("Oilers", "Edmonton", Role.Coach));
            teams.Add(new Team("Ooks", "Edmonton", Role.Player));
            teams.Add(new Team("Canucks", "Vancouver", Role.Other));


            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, teams);

            //Assert
            player.Should().NotBeNull();//was it instantiated
            //Optional
            player.FirstName.Should().Be("Shane");
            player.LastName.Should().Be("Bell");
            player.NumberOfTeams.Should().Be(3);
            player.teams.Should().NotBeNull();
        }






    }
}