using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Any : IPattern
    {
        private string accepted;
        public Any(string accepted)
        {
            this.accepted = accepted;
        }
        public IMatch Match(string text)
        {
            return !string.IsNullOrEmpty(text) && accepted.Contains(text[0])
                ? new Match(text.Substring(1), true)
                : new Match(text, false);
        }
    }
}
