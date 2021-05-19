using System.Drawing;

using Console = Colorful.Console;

namespace jw_robot
{
    public class UserInterface
    {
        private int _startRow = 12;
        private int _startCol = 0;
        
        public void WelcomeTitle(string title)
        {
            Console.Clear();
            Console.WriteAscii(title, Color.Chartreuse);
            System.Console.WriteLine("By Joakim Hall\n");
            Console.WriteLine("FieldSize: ", Color.Coral); // Row  8
            Console.WriteLine("Starting Position: ",Color.Coral);// Row  9 { val: col 18}
            Console.WriteLine("Instructions: ",Color.Coral);// Row  10
        }

        private void UpdateValues(int row, string value)
        {
            Console.SetCursorPosition(_startCol + 19, row);
            Console.Write(value);
        }

        public void AddFinalReport(Position finalPosition)
        {
            Console.SetCursorPosition(29, 9);
            Console.WriteLine($"Final Position: X: {finalPosition.X}, Y: {finalPosition.Y}, Facing: {finalPosition.Facing}", Color.Goldenrod);// Row  10
        }

        public (int x, int y) InputFieldSize()
        {
            int[] inputValues;
            Console.SetCursorPosition(_startCol, _startRow);
            Console.WriteFormatted("Enter field size. {0}", Color.YellowGreen, Color.SeaGreen,"(Ex: 5 6): ");
            while (!Validator.TryParseIntList(Console.ReadLine().Trim(), out inputValues, 2))
            {
                Console.SetCursorPosition(_startCol, _startRow);
                Helpers.ClearCurrentConsoleLine();
                Console.WriteLine("Invalid Input. Try Again...", Color.Crimson);
                Helpers.ClearCurrentConsoleLine();
                Console.SetCursorPosition(_startCol, _startRow+1);
                Console.WriteFormatted("Enter field size. {0}", Color.YellowGreen, Color.SeaGreen,"(Ex: 5 6): ");
            }

            UpdateValues(8, $"{inputValues[0]} {inputValues[1]}");
            return (inputValues[0], inputValues[1]);
        }

        public Position InputStartPosition((int x, int y) fieldSize)
        {
            var inputValues = new Position();
            
            Console.SetCursorPosition(_startCol, _startRow);
            Console.WriteLineFormatted("Enter Starting position and what direction the robot should face. \nUse {0} for direction {1} ",Color.YellowGreen, Color.SeaGreen,"N/E/S/W", "(Ex: 2 3 N): ");
            Console.Write("Start position, X / Y, can't be lower or larger than the field size: ",Color.SeaGreen);

            while (!Validator.ValidateInputStartPosition(Console.ReadLine(), inputValues, fieldSize))
            {
                Console.SetCursorPosition(_startCol, _startRow);
                Helpers.ClearCurrentConsoleLine(3);
                Console.WriteLine("Invalid Input. Try Again...", Color.Crimson);
                Helpers.ClearCurrentConsoleLine();
                Console.SetCursorPosition(_startCol, _startRow+1);
                Console.WriteLineFormatted("Enter Starting position and what direction the robot should face. \nUse {0} for direction {1} ",Color.YellowGreen, Color.SeaGreen,"N/E/S/W", "(Ex: 2 3 N): ");
                Console.Write("Start position, X / Y, can't be lower or larger than the field size: ", Color.SeaGreen);
            }
            
            UpdateValues(9, $"{inputValues.X} {inputValues.Y} {inputValues.Facing}");
            return inputValues;
        }

        public Instructions[] InputInstructions()
        {
            Instructions[] instructions;
            Console.SetCursorPosition(_startCol, _startRow);
            Helpers.ClearCurrentConsoleLine(5);
            Console.WriteLine("Enter move instructions for the robot.",Color.SeaGreen);
            Console.WriteFormatted("Use {0} to turn Right, {1} to turn Left, {2} to walk Froward. {3}",Color.YellowGreen, Color.SeaGreen, new string[]{"R","L","F","(Ex: FRFFLFLLF):"} );

            while (!Validator.ValidateInstructions(Console.ReadLine(), out instructions))
            {
                Console.SetCursorPosition(_startCol, _startRow);
                Helpers.ClearCurrentConsoleLine(5);
                Console.WriteLine("Invalid Input. Try Again...", Color.Crimson);
                Console.WriteLine("Enter move instructions for the robot.",Color.SeaGreen);
                Console.WriteFormatted("Use {0} to turn Right, {1} to turn Left, {2} to walk Froward. {3}",Color.YellowGreen, Color.SeaGreen, new string[]{"R","L","F","(Ex: FRFFLFLLF):"} );
            }

            return instructions;
        }
    }
}