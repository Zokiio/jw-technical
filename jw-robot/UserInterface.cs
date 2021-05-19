using System;
using System.Drawing;
using System.Linq;
using Console = Colorful.Console;

namespace jw_robot
{
    public class UserInterface
    {
        private int startRow = 12;
        private int startCol = 0;
        
        public void WelcomeTitle(string title)
        {
            Console.Clear();
            Console.WriteAscii(title, Color.Chartreuse);
            System.Console.WriteLine("By Joakim Hall\n");
            Console.WriteLine("FieldSize: ", Color.Coral); // Row  8
            Console.WriteLine("Starting Position: ",Color.Coral);// Row  9 { val: col 18}
            Console.WriteLine("Instructions: ",Color.Coral);// Row  10
        }

        public void UpdateValues(int row, string value)
        {
            Console.SetCursorPosition(startCol + 19, row);
            Console.Write(value);
        }

        public (int x, int y) InputFieldSize()
        {
            int[] inputValues;
            Console.SetCursorPosition(startCol, startRow);
            Console.WriteFormatted("Enter field size. {0}", Color.YellowGreen, Color.SeaGreen,"(Ex: 5 6): ");
            while (!Helpers.TryParseIntList(Console.ReadLine(), out inputValues, 2))
            {
                Console.SetCursorPosition(startCol, startRow);
                Helpers.ClearCurrentConsoleLine();
                Console.WriteLine("Invalid Input. Try Again...", Color.Crimson);
                Helpers.ClearCurrentConsoleLine();
                Console.SetCursorPosition(startCol, startRow+1);
                Console.WriteFormatted("Enter field size. {0}", Color.YellowGreen, Color.SeaGreen,"(Ex: 5 6): ");
            }

            UpdateValues(8, $"{inputValues[0]} {inputValues[1]}");
            return (inputValues[0], inputValues[1]);
        }
        
        public Position InputStartPosition()
        {
            string[] input;
            int[] parsed;
            Position inputValues;
            
            
            Console.SetCursorPosition(startCol, startRow);
            Console.WriteFormatted("Enter Starting position and what direction the robot should face. \nUse {0} for direction {1} ",Color.YellowGreen, Color.SeaGreen,"N/E/S/W", "(Ex: 2 3 N): ");
            // TODO: Check Correct input
            input = Console.ReadLine().Split();
            while (!Helpers.TryParseIntList($"{input[0]} {input[1]}", out parsed, 2))
            {
                Console.SetCursorPosition(startCol, startRow+1);
                Helpers.ClearCurrentConsoleLine();
                Console.WriteLine("Invalid Input. Try Again...", Color.Crimson);
                Helpers.ClearCurrentConsoleLine();
                Console.SetCursorPosition(startCol, startRow+2);
                Console.WriteFormatted("Enter Starting position and what direction the robot should face. \nUse {0} for direction {1} ",Color.YellowGreen, Color.SeaGreen,"N/E/S/W", "(Ex: 2 3 N): ");
                Console.ReadKey();
                break;
            }
            inputValues.Facing = input[2];
            inputValues.X = parsed[0];
            inputValues.Y = parsed[1];
            UpdateValues(9, $"{input[0]} {input[1]} {input[2]}");
            return inputValues;
        }

        public char[] InputInstructions()
        {
            Console.SetCursorPosition(startCol, startRow);
            Helpers.ClearCurrentConsoleLine();
            Console.WriteLine("Enter move instructions for the robot.",Color.SeaGreen);
            Console.WriteFormatted("Use {0} to turn Right, {1} to turn Left, {2} to walk Froward. {3}",Color.YellowGreen, Color.SeaGreen, new string[]{"R","L","F","(Ex: FRFFLFLLF):"} );
            var input = Console.ReadLine();
            // TODO: Typecheck input
            UpdateValues(10, input);
            var split = input.ToCharArray();
            
            return split;
        }
    }
}