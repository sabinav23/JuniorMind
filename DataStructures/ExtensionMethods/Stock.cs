using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExtensionMethods
{
    public class Stock
    {
        public string Name { get; set; }
        private int Quantity { get; set; }
        private readonly IEnumerable<int> threshold = new int[] {10, 5, 2};
        private Action<int, string> notify;

        public Stock(string name, int quantity, Action<int, string> notify)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.notify = notify;
        }

        public void UpdateStock(int bought)
        {
            var originalQuantity = this.Quantity;
            this.Quantity -= bought;

            var found = threshold.FirstOrDefault(x => originalQuantity > x && this.Quantity < x);

            if (found != default)
            {
                notify(Quantity, Name);
            }
        }
    }
}
