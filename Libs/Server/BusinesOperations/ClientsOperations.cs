using System.Data.Objects;
using System.Linq;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.Libs.Server.BusinesOperations.Interfaces;
using ClassLibrary1;

namespace Camiher.Libs.Server.BusinesOperations
{
    public class ClientsOperations : IClientsOperations
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

        /// <summary>
        /// Return all Sold Products 
        /// </summary>
        /// <returns>all Sold Products</returns>
        public ObjectSet<ItemSoldProductList> GetSoldProductsByClient(string clientId)
        {
            var dataDc = new Model1Container();
            var soldProducts = dataDc.ProductsSet.Where(s => s.Enventa == "False" && s.Enbusca == "False" && s.Proveedor_ID != "Borrado");
            return (ObjectSet<ItemSoldProductList>)(from c in soldProducts
                join sale in dataDc.SaleSet.Where(S => S.Client_ID == clientId)
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
            var dataDc = new Model1Container();
            return (ObjectSet<ProductsSet>) dataDc.ProductsSet.Where(s => s.Enventa == "False" && s.Enbusca == "False" && s.Proveedor_ID != "Borrado");          
        }



    }
}
