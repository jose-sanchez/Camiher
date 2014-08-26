
using System.Linq;
using BusinesOperations.Interfaces;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;

namespace Camiher.Libs.Server.BusinesOperations
{
    public class ProductsOperation:IProductsOperations
    {
        /// <summary>
        /// Get a product by its productID
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public ProductsSet GetProductById(string productId)
        {
            var dataDc = new Model1Container();
            ProductsSet product = dataDc.ProductsSet.First(s => s.Id == productId);
            return product;
        }

        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if product store succesfully</returns>
        public bool AddProduct(ProductsSet product)
        {
            var dataDc = new Model1Container();
            dataDc.ProductsSet.AddObject(product);
            dataDc.SaveChanges();
            return true;
        }

        public bool DeleteProductById(string productId)
        {
            var dataDc = new Model1Container();
            var product = dataDc.ProductsSet.First(s => s.Id == productId);
            if (product != null)
            {
                dataDc.ProductsSet.DeleteObject(product);
                dataDc.SaveChanges();
                return true;
            }
            else
            {
                //AddLogger
                return false;
            }

            
            
        }
    }
}
