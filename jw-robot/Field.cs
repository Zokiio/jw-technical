namespace jw_robot
{
    public class Field
    {
        public int Width { get; set; }
        public int Depth { get; set; }

        public Field(int width, int depth)
        {
            Width = width;
            Depth = depth;
        }
    }
}