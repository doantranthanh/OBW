using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using OrbusDevTest.DataAccess;
using OrbusDevTest.DataAccess.Codes;
using OrbusDevTest.DataAccess.Models;
using OrbusDevTest.DataAccess.OAService;
using OrbusDevTest.DataAccess.Repository.Product;

namespace ODT.DataAccessTests.ProductDataAccessTests
{
    [TestFixture(Category = "ProductRepositoryTests")]
    public class ProductRepositoryShould
    {
        private ProductRepository _productRepository;
        private Mock<IOAServiceAgent> _mockIOAService;
        private DimProduct[] _mockDimProducts = new DimProduct[3];

        [SetUp]
        public void SetUp()
        {
            _mockIOAService = new Mock<IOAServiceAgent>();
            _productRepository = new ProductRepository(_mockIOAService.Object);
            _mockDimProducts[0] = new DimProduct()
            {
                EnglishProductName = "Fruit",
                ProductKey = 1,
                SafetyStockLevel = 123
            };
            _mockDimProducts[1] = new DimProduct()
            {
                EnglishProductName = "Bread",
                ProductKey = 2,
                SafetyStockLevel = 456
            };
            _mockDimProducts[2] = new DimProduct()
            {
                EnglishProductName = "Coca",
                ProductKey = 3,
                SafetyStockLevel = 789
            };
        }

        [Test]
        public void Be_Able_To_Get_Products_From_SQL_DataBase_Throuth_OAService()
        {
            // Arrange
            _mockIOAService.Setup(x => x.GetProducts()).Returns(_mockDimProducts);
            // Act
            var result = _productRepository.GetProducts();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3,result.Count());
            Assert.AreEqual(_mockDimProducts[0].EnglishProductName, result.First().Name);
            Assert.AreEqual(_mockDimProducts[1].ProductKey, result.ElementAt(1).ProductKey);
            Assert.AreEqual(_mockDimProducts[2].SafetyStockLevel, result.ElementAt(2).StockLevel);
        }

        [Test]
        public void Be_Able_To_Get_Products_By_Id_From_SQL_DataBase_Throuth_OAService()
        {
            // Arrange
            _mockIOAService.Setup(x => x.GetProduct(It.IsAny<int>())).Returns(_mockDimProducts[0]);
            // Act
            var result = _productRepository.GetProduct(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_mockDimProducts[0].EnglishProductName, result.Name);
            Assert.AreEqual(_mockDimProducts[0].ProductKey, result.ProductKey);
            Assert.AreEqual(_mockDimProducts[0].SafetyStockLevel, result.StockLevel);
        }

        [Test]
        public void Be_Able_To_Update_Products_By_To_SQL_DataBase_Throuth_OAService()
        {
            // Arrange
            var updatedProduct = new Product()
            {
                Name = "Beer",
                ProductKey = 4,
                StockLevel = 555
            };
            _mockIOAService.Setup(x => x.UpdateProduct(It.IsAny<DimProduct>())).Returns(updatedProduct.ProductKey);

            // Act
            var result = _productRepository.UpdateProduct(updatedProduct);

            // Assert
 
            Assert.AreEqual(true, result);
        }

        [Test]
        public void Be_Able_To_Get_Products_By_SubCateogory_Id_From_SQL_DataBase_Throuth_OAService()
        {
            // Arrange
            _mockIOAService.Setup(x => x.GetProductsbySubCategoryId(It.IsAny<int>())).Returns(_mockDimProducts);

            // Act
            var result = _productRepository.GetProductsBySubCateogoryId(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count());
            Assert.AreEqual(_mockDimProducts[0].EnglishProductName, result.First().Name);
            Assert.AreEqual(_mockDimProducts[1].ProductKey, result.ElementAt(1).ProductKey);
            Assert.AreEqual(_mockDimProducts[2].SafetyStockLevel, result.ElementAt(2).StockLevel);
        }
    }
}
