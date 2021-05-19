namespace jw_robot
{
    public struct Position
    {
        public int X;
        public int Y;
        public string Facing;
        
        public Position(int x, int y, string facing)
        {
            X = x;
            Y = y;
            Facing = facing;
        }
    }
}