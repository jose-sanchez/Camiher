using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Camiher.Libs.Server.DAL.CamiherDAL;
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
        BaseResponse AddProduct(ProductsSet product, IEnumerable<ProductTranslations> productTranslation );

        /// <summary>
        /// Delete a specific product via productID
        /// </summary>
        /// <param name="productId">product Identificator</param>
        /// <returns></returns>
        [OperationContract]
        BaseResponse DeleteProduct(string productId);

        /// <summary>
        /// Add a product to the database
        /// </summary>
        /// <param name="product">product to add</param>
        /// <param name="productTranslation">language translations</param>
        /// <returns>true if product updated succesfully</returns>
        [OperationContract]
        BaseResponse UpdateProduct(ProductsSet product, IEnumerable<ProductTranslations> productTranslation);
        
        /// <summary>
        /// Get a specific translation for a specific product
        /// </summary>
        /// <param name="productId">product id</param>
        /// <param name="language">language to recover</param>
        /// <returns></returns>
        [OperationContract]
        ProductsTranslationResponse GetProductsTranslations(string productId, string language);

        /// <summary>
        /// Get all the images for a specific product
        /// </summary>
        /// <param name="productId">product id</param>
        /// <returns>Images for the product</returns>
        [OperationContract]
        ProductsImagesResponse GetProductImages(string productId);

        /// <summary>
        /// Delete all images for a specific product
        /// </summary>
        /// <param name="productId">productid</param>
        /// <returns>Response with information about the success of the operation</returns>
        [OperationContract]
        BaseResponse DeleteProductImages(string productId);

        /// <summary>
        /// Delete a Image via its id
        /// </summary>
        /// <param name="imageId">image id</param>
        /// <returns>Response with information about the success of the operation</returns>
        [OperationContract]
        BaseResponse DeleteProductImage(string imageId);

        /// <summary>
        /// Add a image for a product
        /// </summary>
        /// <param name="image">data containing product Id and image data</param>
        /// <returns>Response with information about the success of the operation</returns>
        [OperationContract]
        BaseResponse AddProductImage(ProductImageSet image);

        /// <summary>
        /// Get Products from db
        /// </summary>
        /// <param name="language">product langage which will be retrieved</param>
        /// <returns>product list filtered. If filter is not good format error</returns>
        [OperationContract]
        ProductsResponse GetProducts(string language);

        /// <summary>
        ///  Add picture in base64 format to a product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="picture"></param>
        /// <returns>product list filtered. If filter is not good format error</returns>
        [OperationContract]
        BaseResponse AddPictureToProduct(string productId, string picture);

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
