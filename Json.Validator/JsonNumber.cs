using System;
using System.Linq;

namespace Json
{
    public static class JsonNumber
    {
        public static bool IsJsonNumber(string input)
        {
            if (string.IsNullOrEmpty(input) || StartsWithLeadingZero(input) || !HasMaxOneFractionalPart(input))
            {
                return false;
            }

            // Has fractional part
            if (input.Contains('.'))
            {
                int index = input.IndexOf('.');
                return IsIntegerPartValid(input.Substring(0, index)) && IsFractionalPartValid(input.Substring(index + 1));
            }

            // Does not have fractional part
            return IsNonFractionalNumberValid(input);
        }

        private static bool StartsWithLeadingZero(string input)
        {
            return input.Length > 1 && input[0] == '0' && input[1] != '.';
        }

        private static bool IsValidExponent(string input)
        {
            return IsExponentialComplete(input) && HasValidSignAndOnlyDigits(input);
        }

        private static bool IsExponentialComplete(string exponentContent)
        {
            return exponentContent.Length != 0 && (exponentContent.Length != 1 || (!exponentContent[0].Equals('+') && !exponentContent[0].Equals('-')));
        }

        private static bool HasPlusAndMinusAtCorrectPosition(string toVerify)
        {
            return toVerify.IndexOf('+') == 0 || toVerify.IndexOf('-') == 0;
        }

        private static bool HasPlusOrMinus(string toVerify)
        {
            var countPluses = toVerify.Count(c => c == '+');
            var countMinuses = toVerify.Count(c => c == '-');

            return countPluses + countMinuses != 0;
        }

        private static bool HasValidSignAndOnlyDigits(string toVerify)
        {
            if (toVerify.Length > 1)
            {
                return ((HasPlusAndMinusAtCorrectPosition(toVerify) || !HasPlusOrMinus(toVerify)) && IsDigit(toVerify.Substring(1))) || IsDigit(toVerify);
            }

            return IsDigit(toVerify);
        }

        private static bool IsDigit(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] < '0' || input[i] > '9')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsIntegerPartValid(string input)
        {
            return HasValidSignAndOnlyDigits(input);
        }

        private static bool IsFractionalPartValid(string input)
        {
            string toLower = input.ToLower();
            if (toLower.Contains('e') && HasMaxOneExponent(toLower))
            {
                int index = toLower.IndexOf('e');
                if (index != 0)
                {
                    return IsDigit(input.Substring(0, index)) && IsValidExponent(input.Substring(index + 1));
                }
            }

            return IsDigit(input);
        }

        private static bool HasMaxOneFractionalPart(string input)
        {
            int length = input.Length;
            var count = input.Count(c => c == '.');

            return count <= 1 && input[length - 1] != '.';
        }

        private static bool IsNonFractionalNumberValid(string input)
        {
            string toLower = input.ToLower();
            if (toLower.Contains('e') && HasMaxOneExponent(toLower))
            {
                int index = toLower.IndexOf('e');
                if (index != 0)
                {
                    return HasValidSignAndOnlyDigits(toLower.Substring(0, index)) && IsValidExponent(toLower.Substring(index + 1));
                }
            }

            return HasValidSignAndOnlyDigits(input);
        }

        private static bool HasMaxOneExponent(string input)
        {
            var count = input.Count(c => c == 'e');

            return count <= 1;
        }
    }
}
