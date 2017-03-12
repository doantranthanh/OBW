using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using OrbusDevTest.Controllers;
using OrbusDevTest.DataAccess;
using OrbusDevTest.DataAccess.Models;

namespace OBW.WebDevTests
{
    [TestFixture(Category = "ProductControllerTest")]
    public class ProductControllerShould
    {
        private ProductController _productController;
        private Mock<IProductRepository> _mockProductRespository;
        private List<Product> _mockProducts;
        [SetUp]
        public void SetUp()
        {
            _mockProductRespository = new Mock<IProductRepository>();
            _productController = new ProductController(_mockProductRespository.Object);
            _mockProducts = new List<Product>
            {
                new Product
                {
                    Name = "Product1",
                    ProductKey = 1,
                    StockLevel = 123
                },
                new Product
                {
                    Name = "Product2",
                    ProductKey = 2,
                    StockLevel = 234
                },
            };
        }

        [Test]
        public void Be_Able_To_Return_List_Products()
        {
            // Arrange
            _mockProductRespository.Setup(x => x.GetProducts()).Returns(_mockProducts);

            // Act

            var result = _productController.Index() as ViewResult;

            // Assert
            Assert.NotNull(result.Model);
            Assert.AreEqual(_mockProducts, result.Model);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
