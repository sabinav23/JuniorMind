using System;
using System.Linq;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }

            bool isAcceptedChar = (IsChar(input) && IsValidExponent(input)) || !IsChar(input);
            return isAcceptedChar && !StartsWithLeadingZero(input) && HasOnlyOneFractionalPart(input);
        }

        private static bool StartsWithLeadingZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
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

        private static bool IsValidExponent(string input)
        {
            var counte = input.Count(c => c == 'e');
            var countE = input.Count(c => c == 'E');
            int exponentNumber = counte + countE;
            if (exponentNumber > 1)
            {
                return false;
            }

            if (exponentNumber == 0)
            {
                return false;
            }

            string toLowercase = input.ToLower();
            int index = toLowercase.IndexOf('e');

            if (toLowercase.Substring(index).Length == 1)
            {
                return false;
            }

            return CompleteExponential(input.Substring(index + 1)) && HasOnlyAllowedChars(input.Substring(index + 1));
        }

        private static bool CompleteExponential(string exponentContent)
        {
            if (exponentContent.Length == 0)
            {
                return false;
            }

            if (exponentContent.Length == 1 && (exponentContent[0].Equals('+') || exponentContent[0].Equals('-')))
            {
                return false;
            }

            return true;
        }

        private static bool HasOnlyAllowedChars(string exponentContent)
        {
            const string allowed = "+-";

            for (int i = 0; i < exponentContent.Length; i++)
            {
                if ((exponentContent[i] < '1' || exponentContent[i] > '9') && !allowed.Contains(exponentContent[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsNullOrEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private static bool HasOnlyOneFractionalPart(string input)
        {
            int length = input.Length;
            var count = input.Count(c => c == '.');

            return count <= 1 && input[length - 1] != '.';
        }
    }
}
