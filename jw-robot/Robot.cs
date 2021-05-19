using System;
using static jw_robot.Direction;

namespace jw_robot
{
    public class Robot
    {
        private Position MyPosition { get; set; }
        private (int x, int y) CurrentField { get; set; }

        public Robot(Position myPosition, (int x, int y) currentField)
        {
            MyPosition = myPosition;
            CurrentField = currentField;
        }

        public void Move(char[] instructions)
        {
            foreach (var movement in instructions)
            {
                switch (movement)
                {
                    case 'F':
                        Console.WriteLine("Moving Forward");
                        Forward();
                        break;
                    case 'L':
                        Console.WriteLine("Turn Left");
                        Turn(movement);
                        break;
                    case 'R':
                        Console.WriteLine("Turn Right");
                        Turn(movement);
                        break;
                    default:
                        Console.WriteLine("Unexpected value");
                        break;
                }

                Console.WriteLine(MyPosition.Facing);
                Console.WriteLine(MyPosition.X + " " + MyPosition.Y);
            }
        }

        private void Turn(char turn)
        {
            MyPosition.Facing = turn switch
            {
                'L' => MyPosition.Facing switch
                {
                    N => W,
                    W => S,
                    S => E,
                    E => N,
                    _ => MyPosition.Facing
                },
                'R' => MyPosition.Facing switch
                {
                    N => E,
                    W => N,
                    S => W,
                    E => S,
                    _ => MyPosition.Facing
                },
                _ => MyPosition.Facing
            };
        }

        void Forward()
        {
            if (MyPosition.Facing == N)
            {
                var myPosition = MyPosition;
                if (myPosition.Y !>= CurrentField.y)
                {
                    myPosition.Y += 1;
                }
                
            }
            if (MyPosition.Facing == E)
            {
                var myPosition = MyPosition;
                if (myPosition.X !>= 0)
                {
                    myPosition.X -= 1;
                }
                
            }
            if (MyPosition.Facing == S)
            {
                var myPosition = MyPosition;
                if (myPosition.Y !<= CurrentField.y)
                {
                    myPosition.Y -= 1;
                }
                
            }
            if (MyPosition.Facing == W)
            {
                var myPosition = MyPosition;
                if (myPosition.X !<= 0)
                {
                    myPosition.X += 1;
                }
            }
        }
    }
}