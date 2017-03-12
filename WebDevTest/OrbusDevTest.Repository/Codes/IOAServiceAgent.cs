using System.Collections.Generic;
using OrbusDevTest.DataAccess.OAService;

namespace OrbusDevTest.DataAccess.Codes
{
    public interface IOAServiceAgent
    {
        IEnumerable<DimProduct> GetProducts();
        DimProduct GetProduct(int id);

        DimProductCategory[] GetCategories();

        int UpdateProduct(DimProduct product);

        DimProduct[] GetProductsbySubCategoryId(int subId);

        DimProductSubcategory[] GetSubCategories(int prodId);
    }
}
