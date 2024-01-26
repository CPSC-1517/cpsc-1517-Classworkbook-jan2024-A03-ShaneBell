using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamInheritanceAndCompositionExerciseA03
{
    public class Team
    {
        public int NumberOfPlayers { get; set; }
        public string TeamName { get; set; }
        public string City { get; set; }
        public Season Season { get; set; }
        public List<Player> PlayerList { get; set; }=new();

        public void AddPlayer(string firstName, string lastName, int jerseryNumber)
        {
            //Add a player to the player list
            PlayerList.Add(new Player(firstName, lastName, jerseryNumber));
            //Increment player count
            NumberOfPlayers++;
        }




    }
}
