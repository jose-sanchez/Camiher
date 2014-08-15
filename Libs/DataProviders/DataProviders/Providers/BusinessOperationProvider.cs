using System;
using System.Collections.Generic;
using Camiher.Libs.DataProviders.Camiher;
using Camiher.Libs.DataProviders.Interfaces;
using Camiher.Libs.Server.DAL.CamiherLocalDAL;
using Camiher.Libs.Server.WebServicesObjects;


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
            if (response.ErrorResponse == ResponseError.Ok)
            {
                return response.Sale;
            }
            else
            {
                //AppLogger.Error(String.Format("[BusinessOperationProvider][GetCurrentSale]: response Error '{0}' ", response.ErrorResponse));
                return null;
            }
        }
    }
}
