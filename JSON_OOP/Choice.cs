using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Choice : IPattern
    {
        IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public void Add(IPattern pattern)
        {
            Array.Resize(ref patterns, patterns.Length  + 1);
            patterns[patterns.Length - 1] = pattern;
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
