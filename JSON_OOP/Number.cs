using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var zero = new Character('0');
            var minusSign = new Character('-');
            var plusSign = new Character('+');
            var sign = new Optional(new Choice(plusSign, minusSign));
            var dot = new Character('.');
            var digit = new Range('0','9');
            var digits = new OneOrMore(digit);
            var exponent = new Optional(new Sequence(new Any("eE"), sign, digits));
            var fraction = new Optional(new Sequence(dot, digits));
            var integer = new Sequence(new Optional(minusSign), new Choice(zero, digits));

            pattern = new Sequence(integer, fraction, exponent);
        }
        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
