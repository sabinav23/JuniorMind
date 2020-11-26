using System;

namespace Json
{
    public static class JsonString
    {
        public static bool IsJsonString(string input)
        {
            return !IsNullOrEmpty(input) && HasValidEscapeCharacters(input) && !ContainsControlCharacters(input) && IsWrappedInQuotes(input);
        }

        private static bool IsWrappedInQuotes(string input)
        {
            return input.Length > 1 && input[0].Equals('\"') && input[input.Length - 1].Equals('\"');
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static bool ContainsControlCharacters(string input)
        {
            const int indexForControlCharacters = 32;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < indexForControlCharacters)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasValidEscapeCharacters(string input)
        {
            int sum = 0;
            int i = 0;
            char[] validEscapeCharacters = { '\\', '/', '\"', '\'', 't', 'b', 'n', 'r', 'f', 'u' };

            while (i < input.Length)
            {
                if (input[i].Equals('\\'))
                {
                    sum += IsValid(validEscapeCharacters, input, i + 1);
                    i++;
                }

                i++;
            }

            return sum == 0;
        }

        private static int IsValid(char[] validEscapeCharacters, string input, int position)
        {
            char currentChar = input[position];

            for (int i = 0; i < validEscapeCharacters.Length; i++)
            {
                if (currentChar.Equals(validEscapeCharacters[validEscapeCharacters.Length - 1]) && !CheckIfHexadecimalNumber(input.Substring(position + 1)))
                {
                    return 1;
                }
                else if (currentChar.Equals(validEscapeCharacters[i]) && input.Length - 1 != position)
                {
                    return 0;
                }
            }

            return 1;
        }

        private static bool CheckIfHexadecimalNumber(string numberToCheck)
        {
            const int numberOfExpectedChars = 4;
            if (numberToCheck.Length < numberOfExpectedChars)
            {
                return false;
            }

            const int max = 57;
            const int min = 48;
            for (int i = 0; i < numberOfExpectedChars; i++)
            {
                char currentChar = numberToCheck[i];
                bool betweenDigits = Convert.ToInt32(currentChar) >= min && Convert.ToInt32(currentChar) <= max;
                bool betweenChars = (currentChar >= 'A' && currentChar <= 'F') || (currentChar >= 'a' && currentChar <= 'f');
                if (!betweenDigits && !betweenChars)
                {
                    return false;
                }
            }

            return true;
        }
    }
}