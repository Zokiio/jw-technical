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

        public Position Move(char[] instructions)
        {
            foreach (var movement in instructions)
            {
                switch (movement)
                {
                    case 'F':
                        Forward();
                        break;
                    case 'L':
                        Turn(movement);
                        break;
                    case 'R':
                        Turn(movement);
                        break;
                    default:
                        Console.WriteLine("Unexpected value");
                        break;
                }

                // Console.WriteLine(MyPosition.Facing);
                // Console.WriteLine(MyPosition.X + " " + MyPosition.Y);
            }

            return MyPosition;
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
            switch (MyPosition.Facing)
            {
                case N:
                {
                    if (MyPosition.Y < CurrentField.y)
                    {
                        ++MyPosition.Y;
                    }
                    
                    break;
                }
                case E:
                {
                    if (MyPosition.X < CurrentField.x)
                    {
                       ++MyPosition.X;
                    }

                    break;
                }
                case S:
                {
                    if (MyPosition.Y > CurrentField.y)
                    {
                        --MyPosition.Y;
                    }

                    break;
                }
                case W:
                {
                    if (MyPosition.X > 0)
                    {
                        --MyPosition.X;
                    }

                    break;
                }
                default:
                    Console.WriteLine("Robot went outside");
                    break;
            }
        }
    }
}