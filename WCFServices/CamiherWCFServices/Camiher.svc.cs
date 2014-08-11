using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.Libs.Server.BusinesOperations;

namespace CamiherWCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Camiher : ICamiherService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string ClientBuyProduct(string clientId, string productId, string currentSale)
        {
            var businessOperations = new ClientsOperations();
            businessOperations.ClientBuyProduct(clientId, productId, currentSale);
            return null;
        }

        public SaleSet GetCurrentSale(string clientId, string productId)
        {
            var businessOperations = new ClientsOperations();
            return businessOperations.GetCurrentSale(clientId, productId);
        }
    }
}
