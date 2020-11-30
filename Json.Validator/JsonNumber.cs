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

            bool isAcceptedChar = (!HasValidSignAndOnlyDigits(input) && IsValidExponent(input)) || HasValidSignAndOnlyDigits(input);
            return isAcceptedChar && !StartsWithLeadingZero(input) && HasMaxOneFractionalPart(input);
        }

        private static bool StartsWithLeadingZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        private static bool IsValidExponent(string input)
        {
            string toLower = input.ToLower();
            var count = toLower.Count(c => c == 'e');
            int index = input.ToLower().IndexOf('e');
            if (count != 1 || index < input.IndexOf('.') || toLower.Substring(index).Length == 1)
            {
                return false;
            }

            return IsExponentialComplete(input.Substring(index + 1)) && HasValidSignAndOnlyDigits(input.Substring(index + 1));
        }

        private static bool IsExponentialComplete(string exponentContent)
        {
            return exponentContent.Length != 0 && (exponentContent.Length != 1 || (!exponentContent[0].Equals('+') && !exponentContent[0].Equals('-')));
        }

        private static bool IsValidSign(char toVerify)
        {
            const string allowed = "+-.";
            return allowed.Contains(toVerify);
        }

        private static bool HasValidSignAndOnlyDigits(string toVerify)
        {
            for (int i = 0; i < toVerify.Length; i++)
            {
                if (!IsDigit(toVerify[i]) && !IsValidSign(toVerify[i]))
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

        private static bool HasMaxOneFractionalPart(string input)
        {
            int length = input.Length;
            var count = input.Count(c => c == '.');

            return count <= 1 && input[length - 1] != '.';
        }

        private static bool IsDigit(char charToVerify)
        {
            return charToVerify >= '0' && charToVerify <= '9';
        }
    }
}
