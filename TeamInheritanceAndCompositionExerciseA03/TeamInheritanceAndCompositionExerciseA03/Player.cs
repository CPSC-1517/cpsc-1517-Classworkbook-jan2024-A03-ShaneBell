namespace TeamInheritanceAndCompositionExerciseA03
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JerseyNumber { get; set; }

        public Player (string firstName,  string lastName, int jerseyNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            JerseyNumber = jerseyNumber;
        }
    }
}
