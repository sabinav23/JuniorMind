﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    public class Product
    {
        public string Name { get; set; }
        public ICollection<Feature> Features { get; set; }
        
    }
}
