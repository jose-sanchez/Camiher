using System;
using System.Data.Objects;
using Camiher.Libs.DataProviders.CamiherService;
using Camiher.Libs.DataProviders.Interfaces;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.Libs.Server.WebServicesObjects;
using ClassLibrary1;


namespace Camiher.Libs.DataProviders.Providers
{
    class BusinessOperationProvider : IBusinessOperationProvider
    {
        private readonly CamiherServiceClient _businessOperation;
        public BusinessOperationProvider()
        {
            _businessOperation = new CamiherServiceClient();
            
        }

        public bool ClientBuyProduct(string clientId, string productId, string sale)
        {
            var response = (BaseResponse)_businessOperation.ClientBuyProduct(clientId, productId, sale);
            return response.ErrorResponse == ResponseError.Ok;           
        }

        public SaleSet GetCurrentSale(string clientId, string productId)
        {
            var response = (SaleResponse)_businessOperation.GetCurrentSale(clientId, productId);
            if (response.IsCorrect)
            {               
                return response.Sale;
            }
            else
            {
                //AppLogger.Error(String.Format("[BusinessOperationProvider][GetCurrentSale]: response Error '{0}' ", response.ErrorResponse));
                return null;
            }
        }

        public ObjectSet<ItemSoldProductList> GetSoldProductsByClient(string clientId)
        {
            var response = (SoldProductsResponse)_businessOperation.GetSoldProductsByClient(clientId);
            if (response.IsCorrect)
            {
                return response.Products;
            }
            else
            {
                //AppLogger.Error(String.Format("[BusinessOperationProvider][GetCurrentSale]: response Error '{0}' ", response.ErrorResponse));
                return null;
            }
        }

        public ObjectSet<ProductsSet> GetSoldProducts()
        {
            var response = (ProductsResponse)_businessOperation.GetSoldProducts();
            if (response.IsCorrect)
            {
                return response.Products;
            }
            else
            {
                //AppLogger.Error(String.Format("[BusinessOperationProvider][GetCurrentSale]: response Error '{0}' ", response.ErrorResponse));
                return null;
            }
        }

        public ObjectSet<ProductsSet> GetProductsToSale()
        {
            var response = (ProductsResponse)_businessOperation.GetProducts("Enventa ='True'");
            if (response.IsCorrect)
            {
                return response.Products;
            }
            else
            {
                //AppLogger.Error(String.Format("[BusinessOperationProvider][GetCurrentSale]: response Error '{0}' ", response.ErrorResponse));
                return null;
            }
        }


    }
}
