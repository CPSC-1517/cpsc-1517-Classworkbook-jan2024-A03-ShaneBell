 
using System.Net.Http.Headers;
using ValidationUtilities;

namespace Hockey.Data
{
    /// <summary>
    /// This class will hold hockey player data A03
    /// </summary>
    public class HockeyPlayer
    {
        //Data fields
        //hold data that describe the class 
        //prefix with _ for private fields
        //camel case
        //can use ? to say string datatypes allow nulls
        private string? _birthPlace;
        private DateOnly _dateOfBirth;
        private string? _firstName;
        private string? _lastName;
        private int _heightInInches;
        private int _weightInPounds;
        private int _jerseyNumber;

        //Properties
        //idea is to give public access to fields
        //must have a get
        //could have a private set which can only be called from within the class

        //Create a readonly NumberOfTeams property
        public int NumberOfTeams
        {
            get
            {
                return teams.Count;
            }
        }


        public int JerseyNumber
        {
            get
            {
                return _jerseyNumber;
            }
            set
            {
                if (value < 1 || value > 98)
                {
                    throw new Exception("Jersey Number out of range!");
                }
                _jerseyNumber = value;
            }
        }
        //A property to hold a list of Teams for the player
        public List<Team> teams { get; set; } = new();
        public string BirthPlace
        {
            get
            {
                return _birthPlace;
            }
            set
            {
                if (Utilities.IsNullOrEmptyOrWhiteSpace(value))
                {
                    throw new Exception("Birthplace cannot be null.");
                }
                _birthPlace = value;
            }
        }

        public DateOnly DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                //date cannot be in the future
                if (value > DateOnly.FromDateTime(DateTime.Now))
                {
                    throw new Exception("Cannot be born in the future!");
                }
                _dateOfBirth = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (Utilities.IsNullOrEmptyOrWhiteSpace(value))
                {
                    throw new Exception("First name cannot be null.");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (Utilities.IsNullOrEmptyOrWhiteSpace(value))
                {
                    throw new Exception("Last name cannot be null.");
                }
                _lastName = value;
            }
        }

        public int HeightInInches
        {
            get
            {
                return _heightInInches;
            }
            set
            {
                if (Utilities.IsNegative(value))
                {
                    throw new Exception("Height must be greater than 0.");
                }
                _heightInInches = value;
            }
        }

        public int WeightInPounds
        {
            get
            {
                return _weightInPounds;
            }
            set
            {
                if (Utilities.IsNegative(value))
                {
                    throw new Exception("Weight must be greater than 0.");
                }
                _weightInPounds = value;
            }
        }

        //auto implemented property
        //we don't explicitly code a field to store data
        //a field is created automatically to store the data
        //we don't need validation because it is an enumeration
        public Position Position { get; set; }
        public Shot Shot { get; set; }

        public HockeyPlayer()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _birthPlace = string.Empty;
            _dateOfBirth = new DateOnly();
            _weightInPounds = 0;
            _heightInInches = 0;
            Position = Position.Center;
            Shot = Shot.Right;
            JerseyNumber = 1;
        }

        public HockeyPlayer(string birthPlace, string firstName, string lastName, int heightInInches, int weightInPounds, DateOnly dateOfBirth, Position position, Shot shot,int jerseyNumber,List<Team> teamList )
        {
            BirthPlace = birthPlace;
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            HeightInInches = heightInInches;
            WeightInPounds = weightInPounds;
            Position = position;
            Shot = shot;
            JerseyNumber = jerseyNumber;
            if (teamList != null)
            {
                teams = teamList;
            }
        }
        //Do not allow the addition of a team if it is already in the list.(team name)
        //Throw an exception

        //Overload the AddTeam method to accept a Team object
        //same functionality as the current AddTeam
        //If not team object was passed to the parameter throw an exception
        //(check for null parameter)

        public void AddTeam(Team team)
        {
            //Loop through the list looking for an object with the same Teamname as being added
            if (team==null)
            {
                throw new Exception("A team object was not provided");
            }

            bool found = false;
            foreach (Team aTeam in teams)
            {
                if (aTeam.TeamName == team.TeamName)
                {
                    found = true;
                }
            }
            if (found)
            {
                throw new Exception($"The {team.TeamName} is already listed for that player!");
            }
            teams.Add(team);
        }

        public void AddTeam(string teamName, string city, Role role)
        {
            //Loop through the list looking for an object with the same Teamname as being added
            bool found = false;
            foreach (Team aTeam in teams)            
            {
                if (aTeam.TeamName == teamName)
                {                    
                    found = true;
                }
            }
            if (found)
            {
                throw new Exception($"The {teamName} is alreday listed for that player!");
            }
            teams.Add(new Team(teamName, city, role));
        }

        //Remove a team from the list. Search by the name
        //If the teams was not in the list of teams for that player, throw an exception
        public void RemoveTeam(string teamName) 
        {
            if (string.IsNullOrWhiteSpace(teamName))
            {
                throw new Exception("Must pass a team name to remove");
            }
            bool found = false;
            Team foundTeam = null;

            foreach(Team aTeam in teams)
            {
                if(aTeam.TeamName == teamName) 
                {
                found= true;
                foundTeam = aTeam;
                }
            }
            if (!found)
            {
                throw new Exception($"The player has not played for the team {teamName}");
            }
            teams.Remove(foundTeam);                    
        }

        public static HockeyPlayer Parse(string line)
        {
            HockeyPlayer player;
            if (Utilities.IsNullOrEmptyOrWhiteSpace(line))
            {
                throw new Exception("Line cannot be empty");
            }
            //Split the csv into the array
            string[] fields = line.Split(',');
            if (fields.Length != 9)
            {
                throw new Exception("Incorrect Number of fields");
            }
            try
            {
               
                //if not using JAN (use 01) we dont need the invariant bit....
                //MMM means abreviated month name. Must be capital. lowercase is for minutes
                player = new HockeyPlayer(fields[0], fields[1], fields[2], int.Parse(fields[3]), int.Parse(fields[4]), DateOnly.ParseExact(fields[5], "MM-dd-yyyy"), Enum.Parse<Position>(fields[6]), Enum.Parse<Shot>(fields[7]), int.Parse(fields[8]), null);
            }
            catch
            {
                throw new Exception("Error while creaing the object");
            }
            return player;
        }

    }
}