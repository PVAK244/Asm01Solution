using System;
using BusinessObject;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ProductManagement
    {
        private static ProductManagement instance = null;
        private static readonly object instanceLock = new object();

        private ProductManagement() { }
        public static ProductManagement Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductManagement();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<ProductObject> GetProductList()
        {
            List<ProductObject> products;
            try
            {
                var fStoreDB = new FStoreContext();
                products = fStoreDB.Products.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public ProductObject GetProductById(int productId)
        {
            ProductObject product = null;
            try
            {
                var fStoreDB = new FStoreContext();
                product = fStoreDB.Products.SingleOrDefault(product => product.ProductId == productId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public void AddNew(ProductObject product)
        {
            try
            {
                ProductObject _product = GetProductById(product.ProductId);
                if (_product == null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Products.Add(product);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The product is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(ProductObject product)
        {
            try
            {
                ProductObject p = GetProductById(product.ProductId);
                if (p != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Entry<ProductObject>(product).State = EntityState.Modified;
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(ProductObject product)
        {
            try
            {
                ProductObject _product = GetProductById(product.ProductId);
                if (_product != null)
                {
                    var fStoreDB = new FStoreContext();
                    fStoreDB.Products.Remove(product);
                    fStoreDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The product does not already exist");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
