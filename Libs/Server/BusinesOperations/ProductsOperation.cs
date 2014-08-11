using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationCenter;
using BusinesOperations.Interfaces;

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
