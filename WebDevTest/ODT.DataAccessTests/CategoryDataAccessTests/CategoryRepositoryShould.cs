using System.Linq;
using Moq;
using NUnit.Framework;
using OrbusDevTest.DataAccess.Codes;
using OrbusDevTest.DataAccess.OAService;
using OrbusDevTest.DataAccess.Repository.Category;

namespace ODT.DataAccessTests.CategoryDataAccessTests
{
    [TestFixture(Category = "CategoryRepositoryTests")]
    public class CategoryRepositoryShould
    {
        private CategoryRepository _categoryRepository;
        private Mock<IOAServiceAgent> _mockIOAService;
        private DimProductCategory[] _mockDimProductCategories = new DimProductCategory[2];
        private DimProductCategory _dimProductCategoryOne;
        private DimProductCategory _dimProductCategoryTwo;

        [SetUp]
        public void SetUp()
        {
            _mockIOAService = new Mock<IOAServiceAgent>();
            _categoryRepository = new CategoryRepository(_mockIOAService.Object);

            _dimProductCategoryOne = new DimProductCategory()
            {
                EnglishProductCategoryName = "Product1",
                ProductCategoryKey = 1,
                DimProductSubcategories = new DimProductSubcategory[1]
                {
                    new DimProductSubcategory()
                    {
                        ProductSubcategoryKey = 1,
                        EnglishProductSubcategoryName = "Rice"
                    }
                }
            };
            _dimProductCategoryTwo = new DimProductCategory()
            {

                EnglishProductCategoryName = "Product2",
                ProductCategoryKey = 2,
                DimProductSubcategories = new DimProductSubcategory[1]
               {
                    new DimProductSubcategory()
                    {
                        ProductSubcategoryKey = 2,
                        EnglishProductSubcategoryName = "Noodle"
                    }
               }
            };
            _mockDimProductCategories[0] = _dimProductCategoryOne;
            _mockDimProductCategories[1] = _dimProductCategoryTwo;
         
        }

        [Test]
        public void Be_Able_To_Return_List_Of_Category()
        {
            // Arrange
            _mockIOAService.Setup(x => x.GetCategories()).Returns(_mockDimProductCategories);
            // Act
            var result =_categoryRepository.GetCategories();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual(_dimProductCategoryOne.EnglishProductCategoryName, result.First().Name);
            Assert.AreEqual(_dimProductCategoryTwo.ProductCategoryKey, result.ElementAt(1).Id);
        }

        [Test]
        public void Be_Able_To_Return_List_Of_Sub_Category()
        {
            // Arrange
            _mockIOAService.Setup(x => x.GetSubCategories(It.IsAny<int>())).Returns(_mockDimProductCategories[0].DimProductSubcategories);
            // Act
            var result = _categoryRepository.GetSubCategories(1);
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(_dimProductCategoryOne.DimProductSubcategories[0].EnglishProductSubcategoryName, result.First().Name);
            Assert.AreEqual(_dimProductCategoryOne.DimProductSubcategories[0].ProductSubcategoryKey, result.First().Id);
        }
    }
}
