
namespace Hockey.Data
{
    //the underlying value of an enum is an int
    public enum Position
    {
        //by default, enum start with a value of 0
        //can explicitly set the value if you wish
        LeftWing = 1,
        RightWing,
        Center,
        Defense,
        Goalie
    }
}
