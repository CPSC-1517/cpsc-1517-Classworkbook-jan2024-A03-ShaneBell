using HockeyData;
using System.Net.Http.Headers;
using ValidationUtilities;

namespace Hockey.Data
{
    /// <summary>
    /// This class will hold hockey player data 
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

        //Properties
        //idea is to give public access to fields
        //must have a get
        //could have a private set which can only be called from within the class

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
        }

        public HockeyPlayer(string birthPlace, DateOnly dateOfBirth, string firstName, string lastName, int heightInInches, int weightInPounds, Position position, Shot shot)
        {
            BirthPlace = birthPlace;
            DateOfBirth = dateOfBirth;
            FirstName = firstName;
            LastName = lastName;
            HeightInInches = heightInInches;
            WeightInPounds = weightInPounds;
            Position = position;
            Shot = shot;
        }
        //Do not allow the addition of a team if it is already in the list.(team name)
        //Throw an exception

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



    }
}