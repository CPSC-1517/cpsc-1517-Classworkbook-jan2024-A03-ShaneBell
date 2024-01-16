using Hockey.Data;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HockeyPlayer player1 = new HockeyPlayer();
            //Object Initializer Syntax 
            //Can use the default constructor and set some properties if we want
            HockeyPlayer player2 = new HockeyPlayer
            {
                FirstName = "Connor",
                LastName = "McDavid"
            };

            HockeyPlayer player3 = new HockeyPlayer("Edmonton", new DateOnly(1972, 1, 20), "Shane", "Bell", 70, 190, Position.Goalie, Shot.Right);

            Console.WriteLine($"The players name is {player1.FirstName} {player1.LastName} and they were born on {player1.DateOfBirth}");
            Console.WriteLine($"The players name is {player2.FirstName} {player2.LastName} and they were born on {player2.DateOfBirth}");
            Console.WriteLine($"The players name is {player3.FirstName} {player3.LastName} and they were born on {player3.DateOfBirth}");
            Console.WriteLine($"The players name is {player2.FirstName} {player2.LastName} and they were born on {player2.DateOfBirth}and are in the {player3.Position} position");
        }
    }
}