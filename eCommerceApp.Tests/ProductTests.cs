using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Tests
{
    public class ProductTests
    {
        // Constructor Tests for ProdID
        [Fact]
        public void Constructor_ValidProdID_ShouldInitializeCorrectly()
        {
            var product = new Product(100, "Laptop", 1500.99m, 10);
            Assert.Equal(100, product.ProdID);
        }

        [Fact]
        public void Constructor_ProdID_BelowRange_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(5, "Laptop", 1500.99m, 10));
        }

        [Fact]
        public void Constructor_ProdID_AboveRange_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(100001, "Laptop", 1500.99m, 10));
        }

        // Constructor Tests for ProdName
        [Fact]
        public void Constructor_ValidProdName_ShouldInitializeCorrectly()
        {
            var product = new Product(100, "Laptop", 1500.99m, 10);
            Assert.Equal("Laptop", product.ProdName);
        }

        [Fact]
        public void Constructor_ProdName_EmptyString_ShouldInitialize()
        {
            var product = new Product(100, "", 1500.99m, 10);
            Assert.Equal("", product.ProdName);
        }  
        
        [Fact] 
        public void Constructor_ProdName_Null_ShouldInitialize()
        {
            var product = new Product(100, null, 1500.99m, 10);
            Assert.Null(product.ProdName);
        }

        // 🔹 Constructor Tests for ItemPrice
        [Fact]
        public void Constructor_ValidPrice_ShouldInitializeCorrectly()
        {
            var product = new Product(100, "Laptop", 500.50m, 10);
            Assert.Equal(500.50m, product.ItemPrice);
        }

        [Fact]
        public void Constructor_ItemPrice_BelowRange_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(100, "Laptop", 5m, 10));
        }

        [Fact]
        public void Constructor_ItemPrice_AboveRange_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(100, "Laptop", 20000m, 10));
        }

        // 🔹 Constructor Tests for StockAmount
        [Fact]
        public void Constructor_ValidStockAmount_ShouldInitializeCorrectly()
        {
            var product = new Product(100, "Laptop", 1500.99m, 10);
            Assert.Equal(10, product.StockAmount);
        }

        [Fact]
        public void Constructor_StockAmount_BelowRange_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(100, "Laptop", 1500.99m, 0));
        }

        [Fact]
        public void Constructor_StockAmount_AboveRange_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Product(100, "Laptop", 1500.99m, 200000));
        }
        
    }
}
