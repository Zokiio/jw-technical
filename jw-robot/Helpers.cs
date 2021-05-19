using System;
using System.Drawing;

namespace jw_robot
{
    public static class Helpers
    {
        public static void ClearCurrentConsoleLine(int lines = 1)
        {
            var currentLineCursor = Console.CursorTop;
            for (var i = 1; i <= lines; i++)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth)); 
            }
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void ErrorMessage(string msg = "Invalid Input. Try Again...")
        {
            Console.WriteLine(msg, Color.Crimson);
        }
    }
}