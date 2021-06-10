using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionMethods
{
    public static class LinqMethods
    {
        public static (int, int) VowelsAndCons(string str)
        {
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            char[] cons = { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };

            var strToLower = str.ToLower();

            int totalV = strToLower.Count(c => vowels.Contains(c));

            int totalC = strToLower.Count(c => cons.Contains(c));

            return (totalV, totalC);
        }

        public static char FirstUniqueCharacter(string str)
        {
            char firstDistinctChar = ' ';

            firstDistinctChar = str.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).First();

            return firstDistinctChar;
        }

        public static char MaxAppearances(string str)
        {
            return str.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }

        public static List<string> Palindrom(string str)
        {
            List<string> palindroms = new List<string>();

            for (int i = 0; i < str.Length - 1; i++)
            {
                for(int j = 0; j < str.Length - i; j++)
                {
                    var current = str.Substring(j, i + 1);
                    var reversed = current.Reverse().Where(c => Char.IsLetter(c));
                    if (current.SequenceEqual(reversed))
                    {
                        palindroms.Add(current);
                    }
                }              
            }

            return palindroms;
        }

        public static void SubArraySum(int[] numbers, int result)
        {

        }
    }
}
