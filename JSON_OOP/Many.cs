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
            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());
            }

            return new Match(match.RemainingText(), true);
        }
    }
}
