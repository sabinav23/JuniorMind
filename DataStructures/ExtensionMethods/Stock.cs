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

        public void UpdateStock(Product product, int bought)
        {
            this.quantity -= bought;
            if (this.quantity <= 10)
            {
                DisplayAlertMessage(quantity, product );
            }
        }

        public int GetQuantity()
        {
            return this.quantity;
        }
        private void DisplayAlertMessage(int quantity, Product product)
        {
            if (quantity < 10 && quantity >= 5)
            {
                Console.WriteLine("Only " + quantity + " "  + product + " in stock");
            }
            if (quantity < 5 && quantity >= 2)
            {
                Console.WriteLine("Only " + quantity + " " + product + " in stock");
            }
            if (quantity < 2)
            {
                Console.WriteLine("Only " + quantity + " " + product + " in stock");
            }
        }
    }
}
