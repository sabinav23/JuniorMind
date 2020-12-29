using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Many : IPattern
    {
        private IPattern pattern;
        public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(text, true);
            while (pattern.Match(match.RemainingText()).Success())
            {
                match = new Match(pattern.Match(match.RemainingText()).RemainingText(), true);
            }

            return match;
        }
    }
}
