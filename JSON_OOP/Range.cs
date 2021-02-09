using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    public class Range : IPattern
    {
        private readonly char start;
        private readonly char end;
        private readonly string excepted;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public Range(char start, char end, string excepted)
        {
            this.start = start;
            this.end = end;
            this.excepted = excepted;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(excepted) && !string.IsNullOrEmpty(text) && excepted.Contains(text[0]))
            {
                return new Match(text, false);
            }

            return !string.IsNullOrEmpty(text) && text[0] >= start && text[0] <= end
                ? new Match(text.Substring(1), true)
                : new Match(text, false);
        }
    }
}