using WS.Core.Entities.ChemicalAggregate;

namespace WS.Test.Helpers;

public static class ProductTestHelper
{
    public static List<Product> GetTestProducts()
    {
        // Create a product group
        var productGroup = new ProductGroup()
        {
            GroupName = "Test Product Group",
            Remarks = "Test Remarks"
        };
        
        // Create a product category
        var productCategory = new ProductCategory()
        {
            Category = "Test Product Category",
            ProductGroup = productGroup
        };
        
        // Create a list of products
        var productOne = new Product()
        {
            Id = 1,
            Name = "Test Product 1",
            ProductCategory = productCategory
        };
        
        var productTwo = new Product()
        {
            Id = 2,
            Name = "Test Product 2",
            ProductCategory = productCategory
        };
        
        return new List<Product> { productOne, productTwo };
    }
}