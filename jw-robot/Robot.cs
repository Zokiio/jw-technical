using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace jw_robot
{
    public class Robot
    {
        public Position Position { get; set; }
        public (int x, int y) CurrentField { get; set; }

        public Robot(Position position, (int x, int y) currentField)
        {
            Position = position;
            CurrentField = currentField;
        }

        public void Move(char[] instructions)
        {
            foreach (var movement in instructions)
            {
                switch (movement)
                {
                    case 'F':
                        Console.WriteLine(movement);
                        break;
                    case 'L':
                        Console.WriteLine(movement);
                        break;
                    case 'R':
                        Console.WriteLine(movement);
                        break;
                    default:
                        Console.WriteLine("Unexpected value");
                        break;
                }
            }
        }
    }
}