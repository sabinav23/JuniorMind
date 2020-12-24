using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Text : IPattern
    {
        private string prefix;

        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            return text != null && text.StartsWith(prefix)
                ? new Match(text.Substring(prefix.Length), true)
                : new Match(text, false);
        }
    }
}
