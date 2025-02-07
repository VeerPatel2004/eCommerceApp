using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Tests
{
    public class ProductTests
    {
        // ======================
        // Tests by Veer Patel
        // ======================
        // This test verifies that a valid product ID is properly initialized.
        [Fact]
        public void Constructor_ValidProdID_ShouldInitializeCorrectly()
        {
            // Arrange & Act
            var product = new Product(100, "Laptop", 1500.99m, 10);
            
            // Assert
            Assert.Equal(100, product.ProdID);
        }

        // This test checks if an exception is thrown for a product ID below the valid range.
        [Fact]
        public void Constructor_ProdID_BelowRange_ShouldThrowException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(5, "Laptop", 1500.99m, 10));
        }

        // This test checks if an exception is thrown for a product ID above the valid range.
        [Fact]
        public void Constructor_ProdID_AboveRange_ShouldThrowException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Product(100001, "Laptop", 1500.99m, 10));
        }

        // Constructor Tests for ProdName
        // This test verifies that a valid product name is correctly initialized.
        [Fact]
        public void Constructor_ValidProdName_ShouldInitializeCorrectly()
        {
            // Arrange 
            var product = new Product(100, "Laptop", 1500.99m, 10);
            
            // Act & Assert
            Assert.Equal("Laptop", product.ProdName);
        }

        // This test ensures that an empty product name is properly initialized.
        [Fact]
        public void Constructor_ProdName_EmptyString_ShouldInitialize()
        {
            // Arrange & Act
            var product = new Product(100, "", 1500.99m, 10);
            
            // Assert
            Assert.Equal("", product.ProdName);
        }

        // This test verifies that a null product name is properly initialized.
        [Fact] 
        public void Constructor_ProdName_Null_ShouldInitialize()
        {
            // Arrange & Act
            var product = new Product(100, null, 1500.99m, 10);
            
            // Assert
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

        // IncreaseStock() Tests
        [Fact]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
        {
            var product = new Product(100, "Laptop", 1500.99m, 10);
            product.IncreaseStock(5);
            Assert.Equal(15, product.StockAmount);
        }

        [Fact]
        public void IncreaseStock_Zero_ShouldNotChangeStock()
        {
            var product = new Product(100, "Laptop", 1500.99m, 10);
            product.IncreaseStock(0);
            Assert.Equal(10, product.StockAmount);
        }

        [Fact]
        public void IncreaseStock_NegativeAmount_ShouldThrowException()
        {
            var product = new Product(100, "Laptop", 1500.99m, 10);
            Assert.Throws<ArgumentException>(() => product.IncreaseStock(-5));
        }

        // DecreaseStock() Tests
        [Fact]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
        {
            var product = new Product(100, "Laptop", 1500.99m, 10);
            product.DecreaseStock(5);
            Assert.Equal(5, product.StockAmount);
        }

        [Fact]
        public void DecreaseStock_StockBecomesZero_ShouldWork()
        {
            var product = new Product(100, "Laptop", 1500.99m, 5);
            product.DecreaseStock(5);
            Assert.Equal(0, product.StockAmount);
        }

        [Fact]
        public void DecreaseStock_ExceedingStock_ShouldThrowException()
        {
            var product = new Product(100, "Laptop", 1500.99m, 10);
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(15));
        }
    }
}
