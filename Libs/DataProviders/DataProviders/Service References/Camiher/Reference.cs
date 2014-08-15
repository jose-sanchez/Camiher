﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Camiher.Libs.Server.WebServicesObjects;

namespace Camiher.Libs.DataProviders.Camiher {
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Camiher.ICamiherService")]
    public interface ICamiherService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetData", ReplyAction="http://tempuri.org/ICamiherService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetData", ReplyAction="http://tempuri.org/ICamiherService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICamiherService/GetDataUsingDataContractResponse")]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ICamiherService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<CompositeType> GetDataUsingDataContractAsync(CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/ClientBuyProduct", ReplyAction="http://tempuri.org/ICamiherService/ClientBuyProductResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(SaleResponse))]
        BaseResponse ClientBuyProduct(string clientId, string productId, string currentSale);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/ClientBuyProduct", ReplyAction="http://tempuri.org/ICamiherService/ClientBuyProductResponse")]
        System.Threading.Tasks.Task<BaseResponse> ClientBuyProductAsync(string clientId, string productId, string currentSale);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetCurrentSale", ReplyAction="http://tempuri.org/ICamiherService/GetCurrentSaleResponse")]
        SaleResponse GetCurrentSale(string clientId, string productId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICamiherService/GetCurrentSale", ReplyAction="http://tempuri.org/ICamiherService/GetCurrentSaleResponse")]
        System.Threading.Tasks.Task<SaleResponse> GetCurrentSaleAsync(string clientId, string productId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICamiherServiceChannel : ICamiherService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CamiherServiceClient : System.ServiceModel.ClientBase<ICamiherService>, ICamiherService {
        
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
        
        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<CompositeType> GetDataUsingDataContractAsync(CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public BaseResponse ClientBuyProduct(string clientId, string productId, string currentSale) {
            return base.Channel.ClientBuyProduct(clientId, productId, currentSale);
        }
        
        public System.Threading.Tasks.Task<BaseResponse> ClientBuyProductAsync(string clientId, string productId, string currentSale) {
            return base.Channel.ClientBuyProductAsync(clientId, productId, currentSale);
        }
        
        public SaleResponse GetCurrentSale(string clientId, string productId) {
            return base.Channel.GetCurrentSale(clientId, productId);
        }
        
        public System.Threading.Tasks.Task<SaleResponse> GetCurrentSaleAsync(string clientId, string productId) {
            return base.Channel.GetCurrentSaleAsync(clientId, productId);
        }
    }
}
