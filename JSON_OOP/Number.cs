using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Number : IPattern
    {
        private readonly IPattern pattern;
        private Character zero;
        private Character minusSign;
        private Character plusSign;
        private Optional sign;
        private Character dot;
        private Optional exponent;
        private Optional fraction;
        private Range digit;
        private OneOrMore digits;
        private Sequence integer;

        public Number()
        {
            zero = new Character('0');
            minusSign = new Character('-');
            plusSign = new Character('+');
            sign = new Optional(new Choice(plusSign, minusSign));
            dot = new Character('.');
            digit = new Range('0','9');
            digits = new OneOrMore(digit);
            exponent = new Optional(new Sequence(new Any("eE"), sign, digits));
            fraction = new Optional(new Sequence(dot, digits));
            integer = new Sequence(new Optional(minusSign), new Choice(zero, digits));
            pattern = new Sequence(integer, fraction, exponent);
        }
        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
