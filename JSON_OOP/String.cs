using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var digit = new Range('0', '9');
            var quotesChar = new Character('\"');
            var hex = new Choice(digit, new Range('a', 'f'), new Range('A', 'F'));
            var escape = new Choice(new Any("r\\n\"tbf/"), new Sequence(new Character('u'), hex, hex, hex, hex));
            var interval = new Range((char)32, char.MaxValue, "\\\"");
            var character = new Choice(new Sequence(new Character('\\'), escape), interval);
            var characters = new Many(character);
            var stringPattern = new Sequence(quotesChar, characters, quotesChar);
            
            pattern = stringPattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }

}
