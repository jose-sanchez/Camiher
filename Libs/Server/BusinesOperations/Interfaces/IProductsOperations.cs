using Camiher.Libs.Server.DAL.CamiherLocalDAL;

namespace BusinesOperations.Interfaces
{
    interface IProductsOperations
    {
        ProductsSet GetProductById(string productId);
    }
}
