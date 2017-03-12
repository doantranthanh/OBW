using System.Collections.Generic;
using System.Web.Http;
using OrbusDevTest.DataAccess.Category;
using OrbusDevTest.DataAccess.Codes;
using OrbusDevTest.DataAccess.Models;
using OrbusDevTest.DataAccess.Repository.Category;

namespace OrbusDevTest.Api
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepository _repository;

        public CategoryController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public CategoryController()
        {
            _repository = new CategoryRepository(new OAServiceAgent(new WebServiceEndpointManager()));
        }

        // GET api/Category
        public IEnumerable<Category> Get()
        {
            return _repository.GetCategories();
        }

        // GET api/Category/GetSubCategories/5
        public IEnumerable<Category> GetSubCategories(int categoryId)
        {
            return _repository.GetSubCategories(categoryId);         
        }
    }
}