using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.Libs.Server.WebServicesObjects;


namespace CamiherWCFServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ICamiherService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        BaseResponse ClientBuyProduct(string clientId, string productId, string currentSale);

        [OperationContract]
        SaleResponse GetCurrentSale(string clientId, string productId);

        [OperationContract]
        SoldProductsResponse GetSoldProductsByClient(string clientId);

        [OperationContract]
        ProductsResponse GetSoldProducts();

        [OperationContract]
        BaseResponse AddProduct(ProductsSet product);

        [OperationContract]
        BaseResponse DeleteProduct(string productId);

        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns>true if product updated succesfully</returns>
        [OperationContract]
        BaseResponse UpdateProduct(ProductsSet product);

        /// <summary>
        /// Get Products from db
        /// </summary>
        /// <param name="filter">filter which product should return</param>
        /// <returns>product list filtered. If filter is not good format error</returns>
        [OperationContract]
        BaseResponse GetProducts(string filter);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
