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
            return new HockeyPlayer(BIRTH_PLACE, DATE_OF_BIRTH, FIRST_NAME, LAST_NAME, HEIGHT_IN_INCHES, WEIGHT_IN_POUNDS, PLAYER_POSITION, PLAYER_SHOT, JERSEYNUMBER, null);
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
            player.JerseyNumber = EXPECTED_VALUE;

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

        [Fact]
        public void Add_First_Team()
        {
            //Arrange
            Team firstTeam = new Team("Oilers", "Edmonton", Role.Player);
            //define our expected results after AddTeam
            List<Team> expectedTeamsList = new List<Team>()
            {
                firstTeam
            };
            //expectedTeamsList.Add(firstTeam);
            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, null);
            //Act
            player.AddTeam(firstTeam);
            //Assert
            player.NumberOfTeams.Should().Be(1);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeamsList);
        }

        //Additional teams to collection
        [Fact]
        public void Add_Additional_Teams_To_Collection()
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Player);
            Team team2 = new Team("Ooks", "Edmonton", Role.Player);
            Team team3 = new Team("Canucks", "Edmonton", Role.Player);
            Team additionalTeam = new Team("SQL - Warriors", "Edmonton", Role.Player);

            List<Team> currentTeams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            //define our expected results after AddTeam
            List<Team> expectedTeamsList = new List<Team>()
            {
                team1,
                team2,
                team3,
                additionalTeam
            };
            //expectedTeamsList.Add(firstTeam);
            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, currentTeams);
            //Act
            player.AddTeam(additionalTeam);
            //Assert
            player.NumberOfTeams.Should().Be(4);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeamsList);
        }

        [Fact]
        public void Throw_Missing_Team_Exception()
        {
            //Arrange
            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, null);
            //Act
            Action action = () => player.AddTeam(null);
            //Assert
            player.NumberOfTeams.Should().Be(0);
            player.teams.Should().BeEmpty();
            action.Should().Throw<Exception>().WithMessage("*not provided*");
        }
        [Fact]
        public void Throw_Duplicate_Name_Exception_Adding_Team()
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Player);
            Team team2 = new Team("Ooks", "Edmonton", Role.Player);
            Team team3 = new Team("Canucks", "Edmonton", Role.Player);
            Team additionalTeam = new Team("Oilers", "Edmonton", Role.Player);

            List<Team> currentTeams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            //define our expected results after AddTeam
            List<Team> expectedTeamsList = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, currentTeams);
            //Act
            Action action = () => player.AddTeam(additionalTeam);
            //Assert
            player.NumberOfTeams.Should().Be(3);
            action.Should().Throw<Exception>().WithMessage("*already listed*");
            player.teams.Should().ContainInConsecutiveOrder(expectedTeamsList);
        }

        [Fact]
        public void Remove_Team_From_Collection()
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Player);
            Team team2 = new Team("Ooks", "Edmonton", Role.Player);
            Team team3 = new Team("Canucks", "Edmonton", Role.Player);            

            List<Team> currentTeams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            //define our expected results after AddTeam
            List<Team> expectedTeamsList = new List<Team>()
            {
                team1,
                team3,            
            };
            //expectedTeamsList.Add(firstTeam);
            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, currentTeams);
            //Act
            player.RemoveTeam("Ooks");
            //Assert
            player.NumberOfTeams.Should().Be(2);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeamsList);
        }


        //check for missing teamname exception being thrown on RemoveTeam parameter
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]

        public void Throw_Missing_Team_Name_Exception_Remove_Team(string teamName)
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Player);
            Team team2 = new Team("Ooks", "Edmonton", Role.Player);
            Team team3 = new Team("Canucks", "Edmonton", Role.Player);

            List<Team> currentTeams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            //define our expected results after AddTeam
            List<Team> expectedTeamsList = new List<Team>()
            {
                team1,
                team2,
                team3
            };
            //expectedTeamsList.Add(firstTeam);
            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, currentTeams);
            //Act
            Action action = () => player.RemoveTeam(teamName);
            //Assert
            player.NumberOfTeams.Should().Be(3);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeamsList);
            action.Should().Throw<Exception>().WithMessage("Must pass a team name to remove");
        }

        //Throw a teamname not found exception for Remove Team
        [Fact]
        public void Throw_Team_Name_Not_Found_Exception_Remove_Team()
        {
            //Arrange
            Team team1 = new Team("Oilers", "Edmonton", Role.Player);
            Team team2 = new Team("Ooks", "Edmonton", Role.Player);
            Team team3 = new Team("Canucks", "Edmonton", Role.Player);

           const string removeTeam = "C# Warriors";

            List<Team> currentTeams = new List<Team>()
            {
                team1,
                team2,
                team3
            };

            //define our expected results after AddTeam
            List<Team> expectedTeamsList = new List<Team>()
            {
                team1,
                team2,
                team3
            };
            //expectedTeamsList.Add(firstTeam);
            HockeyPlayer player = new HockeyPlayer("Edmonton", new DateOnly(1972, 01, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right, 1, currentTeams);
            //Act
            Action action = () => player.RemoveTeam(removeTeam);
            //Assert
            player.NumberOfTeams.Should().Be(3);
            player.teams.Should().ContainInConsecutiveOrder(expectedTeamsList);
            action.Should().Throw<Exception>().WithMessage("*has not played*");
        }



    }
}