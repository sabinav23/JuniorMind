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

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            return text[0] == chr;
        }
    }
}
