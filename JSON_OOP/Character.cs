using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Character : IPattern
    {
        private readonly char chr;

        public Character(char chr)
        {
            this.chr = chr;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(null, false);
            }

            bool isMatch = text[0].Equals(chr);
            return new Match(text.Substring(1), isMatch);
        }
    }
}
