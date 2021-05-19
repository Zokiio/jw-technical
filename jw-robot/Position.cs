using System;

namespace jw_robot
{
    public class Position
    {
        public int X;
        public int Y;
        public Direction Facing;
        
        public Position(int x= 0, int y=0, Direction facing = Direction.N)
        {
            X = x;
            Y = y;
            Facing = facing;
        }
    }
}