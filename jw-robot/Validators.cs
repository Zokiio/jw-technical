using System;
using static System.Enum;

namespace jw_robot
{
    public static class Validator
    {
        public static bool ValidateInstructions(string input, out Instructions[] instructions)
        {
            instructions = default;
            var split = input.Trim().Replace(" ", "").ToUpper().ToCharArray();
            var temp = new Instructions[split.Length];
            for (var i = 0; i < split.Length; i++)
            {
                if(!TryParse(split[i].ToString(), out temp[i]))
                {
                    return false;
                }
            }

            instructions = temp;
            return true;
        }
        
        public static bool ValidateInputStartPosition(string input, Position values,(int x, int y) fieldSize)
        {
            var split = input.Trim().ToUpper().Split();
            if (split.Length != 3)
            {
                return false;
            }
            
            var parseX = int.TryParse(split[0], out values.X);
            var parseY = int.TryParse(split[1], out values.Y);
            var parseF = Enum.TryParse(split[2], out values.Facing);
            var (x, y) = fieldSize;
            if(values.X > x || values.Y > y)
            {
                return false;
            }
            return parseX || parseY || parseF;
        }
        
        public static bool TryParseIntList(string input, out int[] inputValues, int length = 0)
        {
            inputValues = default;
            var splits = input.Split(" ");
            var result = new int[splits.Length];
            for (var i = 0; i < splits.Length; i++)
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