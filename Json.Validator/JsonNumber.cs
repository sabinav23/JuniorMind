using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNullOrEmpty(input) && !IsChar(input) && !StartsWithZero(input);
        }

        private static bool StartsWithZero(string input)
        {
            if (input.Length > 1 && input[0] == '0' && input[1] == '.')
            {
                return false;
            }
            else if (input.Length > 1 && input[0] == '0')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsChar(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z'))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
