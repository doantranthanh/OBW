using System.Collections.Generic;
using OrbusDevTest.DataAccess.OAService;

namespace OrbusDevTest.DataAccess.Codes
{
    public class OAServiceAgent : IOAServiceAgent
    {
        private readonly IOAService _oAService;

        public OAServiceAgent(IWebServiceEndpointManager serviceEndpointManager)
        {
            _oAService = serviceEndpointManager.GetOaServiceClient();
        }

        public IEnumerable<DimProduct> GetProducts()
        {
            return _oAService.GetProducts();
        }

        public DimProduct GetProduct(int id)
        {        
            return _oAService.GetProduct(id);
        }

        public DimProductCategory[] GetCategories()
        {
            
            return _oAService.GetCategories();
        }

        public int UpdateProduct(DimProduct product)
        {
            return _oAService.UpdateProduct(product);
        }

        public DimProduct[] GetProductsbySubCategoryId(int subId)
        {
            return _oAService.GetProductsbySubCategoryId(subId);
        }

        public DimProductSubcategory[] GetSubCategories(int prodId)
        {
            return _oAService.GetSubCategories(prodId);
        }
    }
}