using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Optional : IPattern
    {
        private IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return new Match(pattern.Match(text).RemainingText(), true);
        }
    }
}
