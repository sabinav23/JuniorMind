using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Sequence : IPattern
    {
        private IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new Match(text, false);
            foreach (IPattern pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Success().Equals(true))
                {
                    return new Match(text, false);
                }
            }

            return match;
        }
    }
}
