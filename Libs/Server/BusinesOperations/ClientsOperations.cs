using System.Linq;
using AdministrationCenter;
using Camiher.Libs.Server.BusinesOperations.Interfaces;
using Common;
namespace Camiher.Libs.Server.BusinesOperations
{
    class ClientsOperations : IClientsOperations
    {
        public void ClientBuyProduct(string clientId, string productId, string currentSale)
        {
            var dataDc = new Model1Container();
            ProductsSet product = dataDc.ProductsSet.First(s => s.Id == productId);
            SaleSet currentsale = dataDc.SaleSet.First(s => s.Client_ID == clientId
                                                        && s.Product_ID == productId);

            product.Enventa = "false";
            foreach (SaleSet item in dataDc.SaleSet.Where(s => s.Product_ID == productId
                       && s.Id != currentsale.Id))
            {
                dataDc.SaleSet.DeleteObject(item);
            }
            foreach (NotificationSet item in dataDc.NotificationSet.Where(s => s.ProductID == productId))
            {
                dataDc.NotificationSet.DeleteObject(item);
            }
            dataDc.SaveChanges();
        }

        /// <summary>
        /// return current sale for a client and product
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="productId"></param>
        /// <returns></returns>
        public SaleSet GetCurrentSale(string clientId, string productId)
        {

            var dataDc = new Model1Container();
            SaleSet currentsale = dataDc.SaleSet.First(s => s.Client_ID == clientId
                                                        && s.Product_ID == productId);
            return currentsale;

        }
    }
}
