using System;
using System.Collections.Generic;
using System.Web.Http;
using OrbusDevTest.DataAccess.Category;
using OrbusDevTest.DataAccess.Models;

namespace OrbusDevTest.Angular.Api
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            if(categoryRepository == null)
                throw new ArgumentNullException("categoryRepository");
            _categoryRepository = categoryRepository;
        }

        // GET api/Category
        public IEnumerable<Category> Get()
        {
            return _categoryRepository.GetCategories();
        }

        // GET api/Category/GetSubCategories/5
        public IEnumerable<Category> GetSubCategories(int id)
        {
            return _categoryRepository.GetSubCategories(id);
        }
    }
}