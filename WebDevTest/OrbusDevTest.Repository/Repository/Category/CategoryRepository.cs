using System;
using System.Collections.Generic;
using System.Linq;
using OrbusDevTest.DataAccess.Category;
using OrbusDevTest.DataAccess.Codes;

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

        private readonly IOAServiceAgent _oaService;
        public CategoryRepository(IOAServiceAgent oaService)
        {
            if (oaService == null)
                throw new ArgumentNullException("oaService");
            _oaService = oaService;
        }

        public IEnumerable<Models.Category> GetCategories()
        {
            var dimProductCategories = _oaService.GetCategories();
            return dimProductCategories.Select(dimProduct => new Models.Category
            {
                Name = dimProduct.EnglishProductCategoryName,
                Id = dimProduct.ProductCategoryKey
            }).ToList();
        }

        public IEnumerable<Models.Category> GetSubCategories(int categoryId)
        {

            var dimProductSubCategories = _oaService.GetSubCategories(categoryId);
            return dimProductSubCategories.Select(dimSubProduct => new Models.Category
            {
                Name = dimSubProduct.EnglishProductSubcategoryName,
                Id = dimSubProduct.ProductSubcategoryKey
            }).ToList();
        }
    }
}