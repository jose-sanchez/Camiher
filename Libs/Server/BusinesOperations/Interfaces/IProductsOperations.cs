using Camiher.Libs.Server.DAL.CamiherDAL;

namespace BusinesOperations.Interfaces
{
    interface IProductsOperations
    {
        ProductsSet GetProductById(string productId);
    }
}
