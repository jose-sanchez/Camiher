using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationCenter;

namespace Camiher.Libs.Server.BusinesOperations
{
    public class ProductsOperation
    {
        public ProductsSet GetProductById(string productId)
        {
            var _dataDC = new Model1Container();
            ProductsSet Product = _dataDC.ProductsSet.First(S => S.Id == productId);
            return Product;
        }
    }
}
