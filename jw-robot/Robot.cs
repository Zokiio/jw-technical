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

        public Position Move(Instruction[] instructions)
        {
            foreach (var movement in instructions)
            {
                switch (movement)
                {
                    case Instruction.F:
                        Forward();
                        break;
                    case Instruction.L:
                        Turn(movement);
                        break;
                    case Instruction.R:
                        Turn(movement);
                        break;
                    default:
                        Console.WriteLine("Unexpected value");
                        break;
                }
            }

            return MyPosition;
        }

        private void Turn(Instruction turn)
        {
            MyPosition.Facing = turn switch
            {
                Instruction.L => MyPosition.Facing switch
                {
                    N => W,
                    W => S,
                    S => E,
                    E => N,
                    _ => MyPosition.Facing
                },
                Instruction.R => MyPosition.Facing switch
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