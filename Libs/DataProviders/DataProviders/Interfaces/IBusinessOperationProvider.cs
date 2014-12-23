using System;
using System.Collections.Generic;
using System.Data.Objects;
using Camiher.Libs.Server.DAL.CamiherDAL;
using Camiher.Libs.Server.WebServicesObjects;

namespace Camiher.Libs.DataProviders.Interfaces
{
    public interface IBusinessOperationProvider
    {
        bool ClientBuyProduct(string clientId, string productId, string sale);

        SaleSet GetCurrentSale(string clientId, string productId);

        IEnumerable<ItemSoldProductList> GetSoldProductsByClient(string clientId);

        IEnumerable<ProductsSet> GetProductsToSale(string language = null);

        IEnumerable<ProductsSet> GetSoldProducts();

        BaseResponse UpdateProduct(ProductsSet products ,ProductTranslations[] translations = null );
        BaseResponse AddProduct(ProductsSet products, ProductTranslations[] translations = null);
        BaseResponse DeleteProduct(string products);
        BaseResponse AddProductImage(ProductImageSet image);
        BaseResponse DeleteProductImages(String product);
        BaseResponse DeleteProductImage(String imageId);
        ProductsImagesResponse GetProductImages(string product);

    }
}
