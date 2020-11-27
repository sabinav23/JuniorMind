using System;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            return !IsNullOrEmpty(input) && !IsChar(input) && IsGraterOrEqualWithZero(input);
        }

        private static bool IsGraterOrEqualWithZero(string input)
        {
            return Convert.ToInt32(input) >= 0;
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
