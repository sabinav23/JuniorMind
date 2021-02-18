using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Value : IPattern
    {
        private readonly IPattern pattern;

        public Value()
        {
            var ws = new Many(new Any(" \n\r\t"));
            var trueValue = new Text("true");
            var falseValue = new Text("false");
            var nullValue = new Text("null");
            var stringValue = new String();
            var number = new Number();
            var val = new Choice(number, trueValue, falseValue, nullValue, stringValue);
            var element = new Sequence(ws, val, ws);
            var elements = new List(element, new Character(','));
            var member = new Sequence(ws, stringValue, ws, new Character(':'), element);
            var members = new List(member, new Character(','));
            var array = new Sequence(new Character('['), elements, ws, new Character(']'));
            var obj = new Sequence(new Character('{'), members, ws, new Character('}'));
            val.Add(array);
            val.Add(obj);
            pattern = element;
            
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
