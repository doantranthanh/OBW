﻿using System;
using System.Collections.Generic;
using OrbusDevTest.DataAccess.Models;

namespace OrbusDevTest.DataAccess
{
    public class ProductRepository : IProductRepository
    {
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

        public IEnumerable<Product> GetProducts()
        {
            // TODO: Get Products from OAService and map (see mapping above) to the Product client Model
            // (Return only 100 results)
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            // TODO: Get Product from OAService and map (see mapping above) to the Product client Model
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            // TODO: Update Product (Name and StockLevel properties only) and map To DimProduct (OAServer class) (see mapping above)
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsBySubCateogoryId(int subCategoryId)
        {
            // TODO: Get Products from OAService filtered by sub category id and map (see mapping above) to the Product client Model (OAServer method: GetProductsbySubCategoryId)
            throw new NotImplementedException();
        }
    }
}