using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdministrationCenter;

namespace BusinesOperations.Interfaces
{
    interface IProductsOperations
    {
        ProductsSet GetProductById(string productId);
    }
}
