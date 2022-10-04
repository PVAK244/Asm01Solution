using System.Collections.Generic;
using BusinessObject;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<ProductObject> GetProducts() 
            => ProductManagement.Instance.GetProductList();
        public ProductObject GetProductByID(int productId) 
            => ProductManagement.Instance.GetProductById(productId);
        public void InsertProduct(ProductObject product) 
            => ProductManagement.Instance.AddNew(product);
        public void DeleteProduct(ProductObject product)
            => ProductManagement.Instance.Remove(product);
        public void UpdateProduct(ProductObject product)
            => ProductManagement.Instance.Update(product);
    }
}
