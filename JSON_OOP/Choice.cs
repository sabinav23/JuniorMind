using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Choice : IPattern
    {
        readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            foreach (IPattern pattern in patterns)
            {
                IMatch match = pattern.Match(text);
                if(match.Success().Equals(true))
                {             
                    return new Match(match.RemainingText(), true);
                }
            }
            return new Match(text, false);
        }
    }
}
