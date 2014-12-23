using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using Camiher.Libs.Server.DAL.CamiherDAL;
using Camiher.Libs.Server.BusinesOperations.Interfaces;

namespace Camiher.Libs.Server.BusinesOperations
{
    public class ClientsOperations : IClientsOperations
    {
        public void ClientBuyProduct(string clientId, string productId, string currentSale)
        {
            var dataDc = new CamiherContext();
            ProductsSet product = dataDc.Products.First(s => s.Id == productId);
            SaleSet currentsale = dataDc.Sales.First(s => s.Client_ID == clientId
                                                        && s.Product_ID == productId);

            product.Enventa = "false";
            foreach (SaleSet item in dataDc.Sales.Where(s => s.Product_ID == productId
                       && s.Id != currentsale.Id))
            {
                dataDc.Sales.Remove(item);
            }
            foreach (NotificationSet item in dataDc.Notifications.Where(s => s.ProductID == productId))
            {
                dataDc.Notifications.Remove(item);
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

            var dataDc = new CamiherContext();
            SaleSet currentsale = dataDc.Sales.First(s => s.Client_ID == clientId
                                                        && s.Product_ID == productId);
            return currentsale;

        }

        /// <summary>
        /// Return all Sold Products 
        /// </summary>
        /// <returns>all Sold Products</returns>
        public IEnumerable <ItemSoldProductList> GetSoldProductsByClient(string clientId)
        {
            var dataDc = new CamiherContext();
            var soldProducts = dataDc.Products.Where(s => s.Enventa == "False" && s.Enbusca == "False" && s.Proveedor_ID != "Borrado");
            return (ObjectSet<ItemSoldProductList>)(from c in soldProducts
                join sale in dataDc.Sales.Where(S => S.Client_ID == clientId)
                    on c.Id equals sale.Product_ID
                select new ItemSoldProductList
                {
                    Name = c.Producto + " " + c.Marca + " " + c.Modelo,
                    FinalPrice = sale.FinalPrice.ToString() + " Euros",
                    ProductID = c.Id
                });
        }

        public ObjectSet<ProductsSet> GetSoldProducts()
        {
            var dataDc = new CamiherContext();
            return (ObjectSet<ProductsSet>) dataDc.Products.Where(s => s.Enventa == "False" && s.Enbusca == "False" && s.Proveedor_ID != "Borrado");          
        }



    }
}
