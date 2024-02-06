using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hockey.Data
{
    public enum Shot
    {
        Left,
        Right
    }
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

    public enum Role
    {
        Coach,
        Player,
        Trainer,
        Other
    }

}
