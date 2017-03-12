using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OrbusDevTest.DataAccess;
using OrbusDevTest.DataAccess.Models;
using OrbusDevTest.Models;

namespace OrbusDevTest.Controllers
{
    public class ProductController : Controller
    {
        // TODO: Implement IProductRepository to interact with the repository
        private readonly IProductRepository _productRepository;
       

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;         
        }

        //
        // GET: /Product/
        public ActionResult Index()
        {
            //var model = _productRepository.GetProducts();     
            var model = new List<Product>()
            {
                new Product()
                {
                    Name = "P1",
                    ProductKey = 1,
                    StockLevel = 123
                },
                new Product()
                {
                    Name = "P2",
                    ProductKey = 2,
                    StockLevel = 123
                }
            };   
            return View(model);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            var model = _productRepository.GetProduct(id);          
            return View(model);
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _productRepository.GetProduct(id);
            return View(model);
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                _productRepository.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                var errorModel = new ErrorViewModel
                {
                    ErrorMessage = ex.Message
                };
                return View("ErrorPage", errorModel);
            }
        }

        //
        // GET: /Product list
        public ActionResult GetProductListBySubCategory(int subCategoryId)
        {
            var model = _productRepository.GetProductsBySubCateogoryId(subCategoryId);
            return View("SubCategory", model);
        }
    }
}
