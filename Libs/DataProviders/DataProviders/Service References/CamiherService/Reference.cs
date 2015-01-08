﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Camiher.Libs.DataProviders.CamiherService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/CamiherWCFServices")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CamiherService.ICamiherService")]
    public interface ICamiherService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetData", ReplyAction="http://tempuri.org/ICamiherService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetData", ReplyAction="http://tempuri.org/ICamiherService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICamiherService/GetDataUsingDataContractResponse")]
        Camiher.Libs.DataProviders.CamiherService.CompositeType GetDataUsingDataContract(Camiher.Libs.DataProviders.CamiherService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICamiherService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.DataProviders.CamiherService.CompositeType> GetDataUsingDataContractAsync(Camiher.Libs.DataProviders.CamiherService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/ClientBuyProduct", ReplyAction="http://tempuri.org/ICamiherService/ClientBuyProductResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SaleResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse))]
        Camiher.Libs.Server.WebServicesObjects.BaseResponse ClientBuyProduct(string clientId, string productId, string currentSale);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/ClientBuyProduct", ReplyAction="http://tempuri.org/ICamiherService/ClientBuyProductResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> ClientBuyProductAsync(string clientId, string productId, string currentSale);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetCurrentSale", ReplyAction="http://tempuri.org/ICamiherService/GetCurrentSaleResponse")]
        Camiher.Libs.Server.WebServicesObjects.SaleResponse GetCurrentSale(string clientId, string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetCurrentSale", ReplyAction="http://tempuri.org/ICamiherService/GetCurrentSaleResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.SaleResponse> GetCurrentSaleAsync(string clientId, string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetSoldProductsByClient", ReplyAction="http://tempuri.org/ICamiherService/GetSoldProductsByClientResponse")]
        Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse GetSoldProductsByClient(string clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetSoldProductsByClient", ReplyAction="http://tempuri.org/ICamiherService/GetSoldProductsByClientResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse> GetSoldProductsByClientAsync(string clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetSoldProducts", ReplyAction="http://tempuri.org/ICamiherService/GetSoldProductsResponse")]
        Camiher.Libs.Server.WebServicesObjects.ProductsResponse GetSoldProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetSoldProducts", ReplyAction="http://tempuri.org/ICamiherService/GetSoldProductsResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.ProductsResponse> GetSoldProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/AddProduct", ReplyAction="http://tempuri.org/ICamiherService/AddProductResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SaleResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse))]
        Camiher.Libs.Server.WebServicesObjects.BaseResponse AddProduct(Camiher.Libs.Server.DAL.CamiherDAL.ProductsSet product, Camiher.Libs.Server.DAL.CamiherDAL.ProductTranslations[] productTranslation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/AddProduct", ReplyAction="http://tempuri.org/ICamiherService/AddProductResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> AddProductAsync(Camiher.Libs.Server.DAL.CamiherDAL.ProductsSet product, Camiher.Libs.Server.DAL.CamiherDAL.ProductTranslations[] productTranslation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/DeleteProduct", ReplyAction="http://tempuri.org/ICamiherService/DeleteProductResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SaleResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse))]
        Camiher.Libs.Server.WebServicesObjects.BaseResponse DeleteProduct(string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/DeleteProduct", ReplyAction="http://tempuri.org/ICamiherService/DeleteProductResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> DeleteProductAsync(string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/UpdateProduct", ReplyAction="http://tempuri.org/ICamiherService/UpdateProductResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SaleResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse))]
        Camiher.Libs.Server.WebServicesObjects.BaseResponse UpdateProduct(Camiher.Libs.Server.DAL.CamiherDAL.ProductsSet product, Camiher.Libs.Server.DAL.CamiherDAL.ProductTranslations[] productTranslation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/UpdateProduct", ReplyAction="http://tempuri.org/ICamiherService/UpdateProductResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> UpdateProductAsync(Camiher.Libs.Server.DAL.CamiherDAL.ProductsSet product, Camiher.Libs.Server.DAL.CamiherDAL.ProductTranslations[] productTranslation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetProductsTranslations", ReplyAction="http://tempuri.org/ICamiherService/GetProductsTranslationsResponse")]
        Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse GetProductsTranslations(string productId, string language);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetProductsTranslations", ReplyAction="http://tempuri.org/ICamiherService/GetProductsTranslationsResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse> GetProductsTranslationsAsync(string productId, string language);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetProductImages", ReplyAction="http://tempuri.org/ICamiherService/GetProductImagesResponse")]
        Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse GetProductImages(string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetProductImages", ReplyAction="http://tempuri.org/ICamiherService/GetProductImagesResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse> GetProductImagesAsync(string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/DeleteProductImages", ReplyAction="http://tempuri.org/ICamiherService/DeleteProductImagesResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SaleResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse))]
        Camiher.Libs.Server.WebServicesObjects.BaseResponse DeleteProductImages(string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/DeleteProductImages", ReplyAction="http://tempuri.org/ICamiherService/DeleteProductImagesResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> DeleteProductImagesAsync(string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/DeleteProductImage", ReplyAction="http://tempuri.org/ICamiherService/DeleteProductImageResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SaleResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse))]
        Camiher.Libs.Server.WebServicesObjects.BaseResponse DeleteProductImage(string imageId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/DeleteProductImage", ReplyAction="http://tempuri.org/ICamiherService/DeleteProductImageResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> DeleteProductImageAsync(string imageId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/AddProductImage", ReplyAction="http://tempuri.org/ICamiherService/AddProductImageResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SaleResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse))]
        Camiher.Libs.Server.WebServicesObjects.BaseResponse AddProductImage(Camiher.Libs.Server.DAL.CamiherDAL.ProductImageSet image);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/AddProductImage", ReplyAction="http://tempuri.org/ICamiherService/AddProductImageResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> AddProductImageAsync(Camiher.Libs.Server.DAL.CamiherDAL.ProductImageSet image);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetProducts", ReplyAction="http://tempuri.org/ICamiherService/GetProductsResponse")]
        Camiher.Libs.Server.WebServicesObjects.ProductsResponse GetProducts(string language);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetProducts", ReplyAction="http://tempuri.org/ICamiherService/GetProductsResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.ProductsResponse> GetProductsAsync(string language);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/AddPictureToProduct", ReplyAction="http://tempuri.org/ICamiherService/AddPictureToProductResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SaleResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse))]
        Camiher.Libs.Server.WebServicesObjects.BaseResponse AddPictureToProduct(string productId, string picture);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/AddPictureToProduct", ReplyAction="http://tempuri.org/ICamiherService/AddPictureToProductResponse")]
        System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> AddPictureToProductAsync(string productId, string picture);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICamiherServiceChannel : Camiher.Libs.DataProviders.CamiherService.ICamiherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CamiherServiceClient : System.ServiceModel.ClientBase<Camiher.Libs.DataProviders.CamiherService.ICamiherService>, Camiher.Libs.DataProviders.CamiherService.ICamiherService {
        
        public CamiherServiceClient() {
        }
        
        public CamiherServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CamiherServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CamiherServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CamiherServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public Camiher.Libs.DataProviders.CamiherService.CompositeType GetDataUsingDataContract(Camiher.Libs.DataProviders.CamiherService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.DataProviders.CamiherService.CompositeType> GetDataUsingDataContractAsync(Camiher.Libs.DataProviders.CamiherService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.BaseResponse ClientBuyProduct(string clientId, string productId, string currentSale) {
            return base.Channel.ClientBuyProduct(clientId, productId, currentSale);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> ClientBuyProductAsync(string clientId, string productId, string currentSale) {
            return base.Channel.ClientBuyProductAsync(clientId, productId, currentSale);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.SaleResponse GetCurrentSale(string clientId, string productId) {
            return base.Channel.GetCurrentSale(clientId, productId);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.SaleResponse> GetCurrentSaleAsync(string clientId, string productId) {
            return base.Channel.GetCurrentSaleAsync(clientId, productId);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse GetSoldProductsByClient(string clientId) {
            return base.Channel.GetSoldProductsByClient(clientId);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.SoldProductsResponse> GetSoldProductsByClientAsync(string clientId) {
            return base.Channel.GetSoldProductsByClientAsync(clientId);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.ProductsResponse GetSoldProducts() {
            return base.Channel.GetSoldProducts();
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.ProductsResponse> GetSoldProductsAsync() {
            return base.Channel.GetSoldProductsAsync();
        }
        
        public Camiher.Libs.Server.WebServicesObjects.BaseResponse AddProduct(Camiher.Libs.Server.DAL.CamiherDAL.ProductsSet product, Camiher.Libs.Server.DAL.CamiherDAL.ProductTranslations[] productTranslation) {
            return base.Channel.AddProduct(product, productTranslation);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> AddProductAsync(Camiher.Libs.Server.DAL.CamiherDAL.ProductsSet product, Camiher.Libs.Server.DAL.CamiherDAL.ProductTranslations[] productTranslation) {
            return base.Channel.AddProductAsync(product, productTranslation);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.BaseResponse DeleteProduct(string productId) {
            return base.Channel.DeleteProduct(productId);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> DeleteProductAsync(string productId) {
            return base.Channel.DeleteProductAsync(productId);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.BaseResponse UpdateProduct(Camiher.Libs.Server.DAL.CamiherDAL.ProductsSet product, Camiher.Libs.Server.DAL.CamiherDAL.ProductTranslations[] productTranslation) {
            return base.Channel.UpdateProduct(product, productTranslation);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> UpdateProductAsync(Camiher.Libs.Server.DAL.CamiherDAL.ProductsSet product, Camiher.Libs.Server.DAL.CamiherDAL.ProductTranslations[] productTranslation) {
            return base.Channel.UpdateProductAsync(product, productTranslation);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse GetProductsTranslations(string productId, string language) {
            return base.Channel.GetProductsTranslations(productId, language);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.ProductsTranslationResponse> GetProductsTranslationsAsync(string productId, string language) {
            return base.Channel.GetProductsTranslationsAsync(productId, language);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse GetProductImages(string productId) {
            return base.Channel.GetProductImages(productId);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.ProductsImagesResponse> GetProductImagesAsync(string productId) {
            return base.Channel.GetProductImagesAsync(productId);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.BaseResponse DeleteProductImages(string productId) {
            return base.Channel.DeleteProductImages(productId);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> DeleteProductImagesAsync(string productId) {
            return base.Channel.DeleteProductImagesAsync(productId);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.BaseResponse DeleteProductImage(string imageId) {
            return base.Channel.DeleteProductImage(imageId);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> DeleteProductImageAsync(string imageId) {
            return base.Channel.DeleteProductImageAsync(imageId);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.BaseResponse AddProductImage(Camiher.Libs.Server.DAL.CamiherDAL.ProductImageSet image) {
            return base.Channel.AddProductImage(image);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> AddProductImageAsync(Camiher.Libs.Server.DAL.CamiherDAL.ProductImageSet image) {
            return base.Channel.AddProductImageAsync(image);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.ProductsResponse GetProducts(string language) {
            return base.Channel.GetProducts(language);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.ProductsResponse> GetProductsAsync(string language) {
            return base.Channel.GetProductsAsync(language);
        }
        
        public Camiher.Libs.Server.WebServicesObjects.BaseResponse AddPictureToProduct(string productId, string picture) {
            return base.Channel.AddPictureToProduct(productId, picture);
        }
        
        public System.Threading.Tasks.Task<Camiher.Libs.Server.WebServicesObjects.BaseResponse> AddPictureToProductAsync(string productId, string picture) {
            return base.Channel.AddPictureToProductAsync(productId, picture);
        }
    }
}