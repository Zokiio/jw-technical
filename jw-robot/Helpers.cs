using System;

namespace jw_robot
{
    public static class Helpers
    {
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static bool TryParseIntList(string input, out int[] inputValues, int length = 0)
        {
            inputValues = default;
            string[] splits = input.Split(" ");
            int[] result = new int[splits.Length];
            for (int i = 0; i < splits.Length; i++)
            {
                if (!int.TryParse(splits[i].Trim(), out result[i]))
                {
                    return false;
                }
            }
            if (length != 0 && result.Length != length)
            {
                return false;
            }

            inputValues = result;
            return true;
        }
    }
}