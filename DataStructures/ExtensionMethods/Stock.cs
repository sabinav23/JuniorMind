using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    class Stock
    {
        private int quantity;

        public Stock(int quantity)
        {
            this.quantity = quantity;
        }

        public void UpdateStock(string productName, int bought)
        {
            this.quantity -= bought;
            if (this.quantity <= 10)
            {
                DisplayAlertMessage(quantity, productName);
            }
        }

        public int GetQuantity()
        {
            return this.quantity;
        }
        private void DisplayAlertMessage(int quantity, string productName)
        {
            if (quantity < 10 && quantity >= 5)
            {
                Console.WriteLine("Only " + quantity + " "  + productName + " in stock");
            }
            if (quantity < 5 && quantity >= 2)
            {
                Console.WriteLine("Only " + quantity + " " + productName + " in stock");
            }
            if (quantity < 2)
            {
                Console.WriteLine("Only " + quantity + " " + productName + " in stock");
            }
        }
    }
}
