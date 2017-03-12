using System;
using System.Collections.Generic;
using System.Web.Http;
using OrbusDevTest.DataAccess;
using OrbusDevTest.DataAccess.Models;
using OrbusDevTest.DataAccess.Repository.Product;

namespace OrbusDevTest.Angular.Api
{
    public class ProductController : ApiController
    {
        IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            if(repository == null)
                throw new ArgumentNullException("repository");
            _repository = repository;
        }

        // GET api/Product/GetProductListBySubCategory/3
        public IEnumerable<Product> GetProductListBySubCategory(int id)
        {
            return _repository.GetProductsBySubCateogoryId(id);
        }

        [HttpPost]
        public Product Edit(Product product)
        {
            //_repository.UpdateProduct(product);
            throw new NotImplementedException();
        }
    }
}