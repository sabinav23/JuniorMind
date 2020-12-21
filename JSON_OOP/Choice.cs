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

        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            for (int i = 0; i < patterns.Length; i++)
            {
                if (patterns[i].Match(text))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
