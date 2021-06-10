using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    class Product
    {
        private string name;
        private Stock stock;

        public Product(string name, Stock stock)
        {
            this.name = name;
            this.stock = stock;
        }

        public void BuyProduct(int quantity)
        {
            stock.UpdateStock(this.name, quantity);
        }

        public int GetStock()
        {
            return stock.GetQuantity();
        }
    }
}
