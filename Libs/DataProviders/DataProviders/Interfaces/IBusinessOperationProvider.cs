using System.Data.Objects;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.Libs.Server.WebServicesObjects;
using ClassLibrary1;

namespace Camiher.Libs.DataProviders.Interfaces
{
    public interface IBusinessOperationProvider
    {
        bool ClientBuyProduct(string clientId, string productId, string sale);

        SaleSet GetCurrentSale(string clientId, string productId);

        ObjectSet<ItemSoldProductList> GetSoldProductsByClient(string clientId);

        ObjectSet<ProductsSet> GetSoldProducts();
    }
}
