using Hockey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Data
{
    public class Team
    {


        public string TeamName { get; set; }
        public string City { get; set; }
        public Role Role { get; set; }

        public Team(string teamName, string city, Role role)
        {
            TeamName = teamName;
            City = city;
            Role = role;
        }

        public override string ToString() 
        {
            return $"{TeamName},{City},{Role}";        
        }

        //Customer Parse and TryParse methods to return a Team object from a csv string ("Oilers,Edmonton,Player")
        public static Team Parse(string values)
        {
            //values is the csv string
            //Create an array of strings using .Split(,)
            //split the seperate pieces of data that are in the csv string(values) int elements of the array
            string[] valuesArray = values.Split(',');
            // ["Oilers"]["Edmonton"]["Player"]
            return new Team(valuesArray[0], valuesArray[1], (Role)Enum.Parse(typeof(Role),valuesArray[2]));
        }

        //Create a TryParse to return a success bool for the parse and if succeeds parses the string
        public static bool TryParse(string value, out Team team)
        {
            bool valid = false;
            //nice to throw an exception if value is empty
            if (string.IsNullOrEmpty(value)) 
            {
                throw new Exception("String to parse is empty!");
            }
            team = Parse(value);
            valid = true;

            return valid;
        }





    }
}
