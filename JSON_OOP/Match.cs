using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    public class Match : IMatch
    {

        private string remainingText;
        private bool success;

        public Match(string remainingText, bool success)
        {
             this.remainingText = remainingText;
            this.success = success;
        }
        public string RemainingText()
        {
            return this.remainingText;
        }

        public bool Success()
        {
            return this.success;
        }
    }
}
