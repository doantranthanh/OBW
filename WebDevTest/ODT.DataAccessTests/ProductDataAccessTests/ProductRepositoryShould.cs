using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using OrbusDevTest.DataAccess;
using OrbusDevTest.DataAccess.OAService;

namespace ODT.DataAccessTests.ProductDataAccessTests
{
    [TestFixture(Category = "ProductRepositoryTests")]
    public class ProductRepositoryShould
    {
        private ProductRepository _productRepository;
        private Mock<IOAService> _mockIOAService;
        private DimProduct[] _mockDimProducts = new DimProduct[3];

        [SetUp]
        public void SetUp()
        {
            _mockIOAService = new Mock<IOAService>();
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
        public void Get_Products_From_SQL_DataBase_Throuth_OAService()
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
    }
}
