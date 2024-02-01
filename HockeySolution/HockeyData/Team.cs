using Hockey.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyData
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




    }
}
