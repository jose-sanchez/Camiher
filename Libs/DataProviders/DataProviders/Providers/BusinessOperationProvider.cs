using System;
using System.Collections.Generic;
using System.Data.Objects;
using Camiher.Libs.DataProviders.CamiherService;
using Camiher.Libs.DataProviders.Interfaces;
using Camiher.Libs.Server.DAL.CamiherDAL;
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

        public IEnumerable<ItemSoldProductList> GetSoldProductsByClient(string clientId)
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

        public IEnumerable<ProductsSet> GetSoldProducts()
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

        public IEnumerable<ProductsSet> GetProductsToSale(string language = null)
        {
            var response = (ProductsResponse)_businessOperation.GetProducts(language);
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

        public IEnumerable<ProductsSet> GetProductsToSale(string language = null)
        {
            var response = (ProductsResponse)_businessOperation.GetProducts(language);
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

        public BaseResponse UpdateProduct(ProductsSet product,ProductTranslations[] translations = null )
        {
            return (BaseResponse)_businessOperation.UpdateProduct(product, translations);
        }

        public BaseResponse DeleteProduct(String product)
        {
            return (BaseResponse)_businessOperation.DeleteProduct(product);
        }

        public BaseResponse AddProduct(ProductsSet product ,ProductTranslations[] translations = null )
        {
            return (BaseResponse)_businessOperation.AddProduct(product, translations);
        }

        public BaseResponse DeleteProductImages(String product)
        {
            return (BaseResponse)_businessOperation.DeleteProductImages(product);
        }

        public BaseResponse DeleteProductImage(string imageId)
        {
            return (BaseResponse)_businessOperation.DeleteProductImage(imageId);
        }

        public BaseResponse AddProductImage(ProductImageSet image)
        {
            return (BaseResponse)_businessOperation.AddProductImage(image);
        }


        public ProductsImagesResponse GetProductImages(string product)
        {
            return (ProductsImagesResponse)_businessOperation.GetProductImages(product);
        }

        //public ProductsImagesResponse GetFirstImageOfEveryProduct()
        //{
        //    return (ProductsImagesResponse)_businessOperation.GetProductImages();
        //}




    }
}
