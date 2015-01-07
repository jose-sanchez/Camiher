using Camiher.Libs.Server.DAL.CamiherDAL;

namespace Camiher.Libs.Server.BusinesOperations.Interfaces
{
    interface IProductsOperations
    {
        ProductsSet GetProductById(string productId);
    }
}
