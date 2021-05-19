using System;
using static jw_robot.Directions;

namespace jw_robot
{
    public class Robot
    {
        private Position MyPosition { get; set; }
        private Field CurrentField { get; set; }

        public Robot(Position myPosition, Field currentField)
        {
            MyPosition = myPosition;
            CurrentField = currentField;
        }

        public Position Move(Instructions[] instructions)
        {
            foreach (var movement in instructions)
            {
                switch (movement)
                {
                    case Instructions.F:
                        Forward();
                        break;
                    case Instructions.L:
                        Turn(movement);
                        break;
                    case Instructions.R:
                        Turn(movement);
                        break;
                    default:
                        Console.WriteLine("Unexpected value");
                        break;
                }
            }

            return MyPosition;
        }

        private void Turn(Instructions turn)
        {
            MyPosition.Facing = turn switch
            {
                Instructions.L => MyPosition.Facing switch
                {
                    N => W,
                    W => S,
                    S => E,
                    E => N,
                    _ => MyPosition.Facing
                },
                Instructions.R => MyPosition.Facing switch
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

        private void Forward()
        {
            switch (MyPosition.Facing)
            {
                case N:
                {
                    if (MyPosition.Y < CurrentField.Depth)
                    {
                        ++MyPosition.Y;
                    }
                    
                    break;
                }
                case E:
                {
                    if (MyPosition.X < CurrentField.Width)
                    {
                       ++MyPosition.X;
                    }

                    break;
                }
                case S:
                {
                    if (MyPosition.Y > 0)
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