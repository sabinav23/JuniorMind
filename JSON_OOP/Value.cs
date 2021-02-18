using System;
using System.Collections.Generic;
using System.Text;

namespace JSONoop
{
    class Value : IPattern
    {
        private readonly String stringValue;
        private readonly Number number;
        private readonly Choice val;
        private readonly Many ws;
        private readonly Text trueValue;
        private readonly Text falseValue;
        private readonly Text nullValue;
        private readonly Sequence element;
        private readonly List elements;
        private readonly Sequence member;
        private readonly List members;
        private readonly Sequence array;
        private readonly Sequence obj;
        private readonly IPattern pattern;

        public Value()
        {
            ws = new Many(new Any(" \n\r\t"));
            trueValue = new Text("true");
            falseValue = new Text("false");
            nullValue = new Text("null");
            stringValue = new String();
            number = new Number();
            val = new Choice(number, trueValue, falseValue, nullValue, stringValue);
            //val = new Choice(stringValue);
            element = new Sequence(ws, val, ws);
            elements = new List(element, new Character(','));
            member = new Sequence(ws, stringValue, ws, new Character(':'), element);
            members = new List(member, new Character(','));
            array = new Sequence(new Character('['), elements, new Character(']'));
            obj = new Sequence(new Character('{'), members, new Character('}'));
            val.Add(array);
            val.Add(obj);
            val.Add(stringValue);
            pattern = element;
            
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
