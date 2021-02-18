using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class String : IPattern
    {
        private readonly Choice escape;
        private readonly Range interval;
        private readonly Choice character;
        private readonly Optional characters;
        private readonly Sequence stringPattern;
        private readonly Range digit;
        private readonly Character quotesChar;
        private readonly Choice hex;
        private readonly IPattern pattern;

        public String()
        {
            digit = new Range('0', '9');
            quotesChar = new Character('\"');
            hex = new Choice(digit, new Range('a', 'f'), new Range('A', 'F'));
            escape = new Choice(new Any("r\\n\"tbf/"), new Sequence(new Character('u'), hex, hex, hex, hex));
            interval = new Range((char)32, char.MaxValue, "\\\"");
            character = new Choice(new Sequence(new Character('\\'), escape), interval);
            characters = new Optional(new Many(character));
            stringPattern = new Sequence(quotesChar, characters, quotesChar);
            

            pattern = stringPattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }

}
