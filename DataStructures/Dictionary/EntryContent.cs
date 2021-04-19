﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dictionary
{
    class EntryContent<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public int Next { get; set; }

    }
}
