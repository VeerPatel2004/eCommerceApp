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
    }
}
