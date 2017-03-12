using System;
using System.Collections.Generic;
using System.Linq;
using OrbusDevTest.DataAccess.Category;
using OrbusDevTest.DataAccess.OAService;

namespace OrbusDevTest.DataAccess.Repository.Category
{
    public class CategoryRepository : ICategoryRepository
    {
        // TODO: Include OAService, this will allow you to query the webservice

        /*
         * Example of Mapping Between DimProductCategory (OAService) <-> Category (Client Model)
         * 
         * ProductCategoryKey <-> Id,
         * EnglishProductCategoryName <-> Name
         * 
         * 
         * 
         * Example of Mapping Between DimProductSubcategory (OAService) <-> Category (Client Model)
         * 
         * ProductSubcategoryKey <-> Id,
         * EnglishProductSubcategoryName <-> Name
         * 
         * 
         * Don't spend time implementing a 3rd part mapping framework, but try to use Linq if you can
         */

        private readonly IOAService _oaService;
        public CategoryRepository(IOAService oaService)
        {
            if (oaService == null)
                throw new ArgumentNullException("oaService");
            _oaService = oaService;
        }

        public IEnumerable<Models.Category> GetCategories()
        {
            var dimProductSubCategory = _oaService.GetCategories();
            return (from category in dimProductSubCategory
                from subcategory in category.DimProductSubcategories
                select new Models.Category
                {
                    Id = subcategory.ProductSubcategoryKey, Name = subcategory.EnglishProductSubcategoryName
                }).ToList();
        }

        public IEnumerable<Models.Category> GetSubCategories(int categoryId)
        {
            // TODO: Get sub categories by category id from OAService and map (see mapping above) to the Category client Model (OAService Method: GetSubCategories)
            throw new NotImplementedException();
        }
    }
}