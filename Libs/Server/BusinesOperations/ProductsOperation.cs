
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
    }
}
