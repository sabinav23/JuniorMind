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
            return !string.IsNullOrEmpty(text) && text[0] == chr
                ? new Match(text.Substring(1), true)
                : new Match(text, false);
        }
    }
}
