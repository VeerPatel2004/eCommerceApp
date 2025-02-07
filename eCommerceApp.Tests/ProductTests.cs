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
         //============================
        // Tests by Darsan Sabu George 
        // ============================
        //  Constructor for testsing ItemPrice 
        // This test verifies that a valid price is correctly initialized.
        [Fact]
        public void Constructor_ValidPrice_ShouldInitializeCorrectly()
        {
             // Arrange & Act
            var product = new Product(100, "Laptop", 500.50m, 10);
              // Assert
            Assert.Equal(500.50m, product.ItemPrice);
        }

        [Fact] // This test ensures that an exception is thrown when the item price is below the valid range.
        public void Constructor_ItemPrice_BelowRange_ShouldThrowException()
        {
             // Arrange, Act and Assert
            Assert.Throws<ArgumentException>(() => new Product(100, "Laptop", 5m, 10));
        }

        [Fact] // This test ensures that an exception is thrown when the item price is above the valid range.
        public void Constructor_ItemPrice_AboveRange_ShouldThrowException()
        {
              // Arrange, Act and Assert
            Assert.Throws<ArgumentException>(() => new Product(100, "Laptop", 20000m, 10));
        }
        
        // Constructor Tests for StockAmount
        // This test verifies that a valid stock amount is correctly initialized.
        [Fact]
        public void Constructor_ValidStockAmount_ShouldInitializeCorrectly()
        {
            // Arrange & Act   
            var product = new Product(100, "Laptop", 1500.99m, 10);
            // Assert
            Assert.Equal(10, product.StockAmount);
        }
        // This test ensures that an exception is thrown when the stock amount is below the valid range.
        [Fact]
        public void Constructor_StockAmount_BelowRange_ShouldThrowException()
        {
             // Arrange, Act and Assert
            Assert.Throws<ArgumentException>(() => new Product(100, "Laptop", 1500.99m, 0));
        }
         // This test ensures that an exception is thrown when the stock amount is above the valid range.
        [Fact]
        public void Constructor_StockAmount_AboveRange_ShouldThrowException()
        {
             // Arrange, Act and Assert
            Assert.Throws<ArgumentException>(() => new Product(100, "Laptop", 1500.99m, 200000));
        }
        
        //====================================
        //Test By Nandhu krishna Rajendran
        //======================================

        // IncreaseStock() Tests

         // Test to verify that increasing stock by a valid positive amount works correctly
        [Fact]
        public void IncreaseStock_ValidAmount_ShouldIncreaseStock()
        {
            // Arrange: Create a product with an initial stock of 10
            var product = new Product(100, "Laptop", 1500.99m, 10);
             // Act: Increase the stock by 5
            product.IncreaseStock(5);
            // Assert: Verify that the stock has increased to 15
            Assert.Equal(15, product.StockAmount);
        }

        // Test to verify that increasing stock by zero does not change the stock amount
        [Fact]
        public void IncreaseStock_Zero_ShouldNotChangeStock()
        {
            // Arrange: Create a product with an initial stock of 10
            var product = new Product(100, "Laptop", 1500.99m, 10);
            // Act: Attempt to increase the stock by 0
            product.IncreaseStock(0);
             // Assert: Verify that the stock remains unchanged at 10
            Assert.Equal(10, product.StockAmount);
        }

        // Test to verify that increasing stock by a negative amount throws an ArgumentException

        [Fact]
        public void IncreaseStock_NegativeAmount_ShouldThrowException()
        {
             // Arrange: Create a product with an initial stock of 10
            var product = new Product(100, "Laptop", 1500.99m, 10);
            // Act & Assert: Verify that increasing stock with a negative value throws an exception
            Assert.Throws<ArgumentException>(() => product.IncreaseStock(-5));
        }

        // DecreaseStock() Tests

        // Test to verify that decreasing stock by a valid amount reduces the stock correctly
        [Fact]
        public void DecreaseStock_ValidAmount_ShouldDecreaseStock()
        {
            // Arrange: Create a product with an initial stock of 10
            var product = new Product(100, "Laptop", 1500.99m, 10);
            // Act: Decrease the stock by 5
            product.DecreaseStock(5);
            // Assert: Verify that the stock has decreased to 5
            Assert.Equal(5, product.StockAmount);
        }

        // Test to verify that decreasing stock to exactly zero works as expected

        [Fact]
        public void DecreaseStock_StockBecomesZero_ShouldWork()
        {
            // Arrange: Create a product with an initial stock of 5
            var product = new Product(100, "Laptop", 1500.99m, 5);
            // Act: Decrease the stock by 5, reducing it to zero
            product.DecreaseStock(5);
            // Assert: Verify that the stock is now zero
            Assert.Equal(0, product.StockAmount);
        }

        // Test to verify that decreasing stock by more than the available amount throws an InvalidOperationException

        [Fact]
        public void DecreaseStock_ExceedingStock_ShouldThrowException()
        {
            // Arrange: Create a product with an initial stock of 10
            var product = new Product(100, "Laptop", 1500.99m, 10);
            // Act & Assert: Verify that attempting to decrease stock by more than available throws an exception
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(15));
        }
    }
}
