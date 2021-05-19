using System;

namespace jw_robot
{
    public class Position
    {
        public int X;
        public int Y;
        public Directions Facing;
        
        public Position(int x = 0, int y = 0, Directions facing = Directions.N)
        {
            X = x;
            Y = y;
            Facing = facing;
        }
    }
}