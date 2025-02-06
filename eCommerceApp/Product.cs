using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp
{
    public class Product
    {
        // Properties
        public int ProdID { get; set; }
        public string ProdName { get; set; }
        public decimal ItemPrice { get; set; }
        public int StockAmount { get; private set; }  // Stock should not be directly set

        // Constructor
        public Product(int prodID, string prodName, decimal itemPrice, int stockAmount)
        {
            if (prodID < 10 || prodID > 100000)
                throw new ArgumentException("Product ID must be between 10 and 100000.");

            if (itemPrice < 10 || itemPrice > 10000)
                throw new ArgumentException("Item price must be between $10 and $10000.");

            if (stockAmount < 1 || stockAmount > 100000)
                throw new ArgumentException("Stock must be between 1 and 100000.");

            ProdID = prodID;
            ProdName = prodName;
            ItemPrice = itemPrice;
            StockAmount = stockAmount;
        }

        // Method to increase the stock
        public void IncreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Increase amount cannot be negative.");

            StockAmount += amount;
        }

        // Method to decrease the stock 
        public void DecreaseStock(int amount)
        {
            if (amount < 0)
                throw new ArgumentException("Decrease amount cannot be negative.");

            if (StockAmount - amount < 0)
                throw new InvalidOperationException("Stock cannot be negative.");

            StockAmount -= amount;
        }
    }
}
