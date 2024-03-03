namespace BlazerSampleApp.Data
{
    public class Movie
    {
        public string MovieName { get; set; }
        public string Description { get; set; }
        public char Rating { get; set; }

        public Movie (string movieName,string description, char rating)
        {
            MovieName = movieName;
            Description = description;
            Rating = rating;
        }
        


    }
}
