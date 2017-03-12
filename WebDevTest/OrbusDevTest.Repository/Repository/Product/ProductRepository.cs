using System;
using System.Collections.Generic;
using System.Linq;
using OrbusDevTest.DataAccess.OAService;

namespace OrbusDevTest.DataAccess.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IOAService _oaService;

        public ProductRepository(IOAService oaService)
        {
            if(oaService == null)
                throw new ArgumentNullException("oaService");
            _oaService = oaService;
        }

        // TODO: Include OAService, this will allow you to query the webservice

        /*
         * Example of Mapping Between DimProduct (OAService) <-> Product Mapping (Client Model)
         * 
         * EnglishProductName <-> Name
         * ProductKey <-> ProductKey
         * SafetyStockLevel <-> StockLevel
         * 
         * 
         * Don't spend time implementing a 3rd part mapping framework, but try to use Linq if you can
         */

        public IEnumerable<Models.Product> GetProducts()
        {
            var dimProducts = _oaService.GetProducts();
            return dimProducts.Select(dimProduct => new Models.Product
            {
                Name = dimProduct.EnglishProductName, ProductKey = dimProduct.ProductKey, StockLevel = dimProduct.SafetyStockLevel
            }).ToList();
        }

        public Models.Product GetProduct(int id)
        {
            var dimProduct = _oaService.GetProduct(id);
            return new Models.Product
            {
                Name = dimProduct.EnglishProductName,
                ProductKey = dimProduct.ProductKey,
                StockLevel = dimProduct.SafetyStockLevel
            };
        }

        public bool UpdateProduct(Models.Product product)
        {
            if(product == null)
                throw new ArgumentNullException("product");
            var dimProduct = new DimProduct
            {
                EnglishProductName = product.Name,
                ProductKey = product.ProductKey,
                SafetyStockLevel = product.StockLevel
            };
            var productId =_oaService.UpdateProduct(dimProduct);
            return productId > 0;
        }

        public IEnumerable<Models.Product> GetProductsBySubCateogoryId(int subCategoryId)
        {
            var dimProducts = _oaService.GetProductsbySubCategoryId(subCategoryId);
            return dimProducts.Select(dimProduct => new Models.Product
            {
                Name = dimProduct.EnglishProductName,
                ProductKey = dimProduct.ProductKey,
                StockLevel = dimProduct.SafetyStockLevel
            }).ToList();
        }
    }
}