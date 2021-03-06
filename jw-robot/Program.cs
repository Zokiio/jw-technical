using Console = Colorful.Console;

namespace jw_robot
{
    public class Program
    {
        static void Main(string[] args)
        {
            var userInterface = new UserInterface();
            do
            {
                userInterface.WelcomeTitle("JW Robot");

                var fieldSize = userInterface.InputFieldSize();
                var startingPos = userInterface.InputStartPosition(fieldSize);
                var instructions = userInterface.InputInstructions();

                var robot = new Robot(startingPos, fieldSize);
                var robotPosition = robot.Move(instructions);
                userInterface.AddFinalReport(robotPosition);
            } while (userInterface.Restart());
        }
    }
}