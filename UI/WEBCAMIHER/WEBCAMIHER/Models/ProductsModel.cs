using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Camiher.Libs.DataProviders;
using Camiher.Libs.DataProviders.Interfaces;
using Camiher.Libs.Server.DAL.CamiherDAL;

namespace WEBCAMIHER.Models
{
    public interface IProductModel
    {
        IEnumerable<ProductsSet> GetProductList(string language);
    }

    public class ProductsModel:IProductModel
    {
        private IBusinessOperationProvider _businessOperation;

        public ProductsModel()
        {
            _businessOperation = DataProvidersFactory.GetBusinessOperationProvider();
        }

        public IEnumerable<ProductsSet> GetProductList(string language)
        {
            if (language != "es")
            {
                return _businessOperation.GetProductsToSale();
            }
            return _businessOperation.GetProductsToSale(language);
        }
    }
}