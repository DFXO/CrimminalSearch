﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CriminalSearchRequest", Namespace="http://schemas.datacontract.org/2004/07/NationalCriminal.Search.DataContracts")]
    [System.SerializableAttribute()]
    public partial class CriminalSearchRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.Range AgeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string[] CriminalNamesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.Range HeightField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NationalityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.Sex SexField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.Range WeightField;
        
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
        public NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.Range Age {
            get {
                return this.AgeField;
            }
            set {
                if ((object.ReferenceEquals(this.AgeField, value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string[] CriminalNames {
            get {
                return this.CriminalNamesField;
            }
            set {
                if ((object.ReferenceEquals(this.CriminalNamesField, value) != true)) {
                    this.CriminalNamesField = value;
                    this.RaisePropertyChanged("CriminalNames");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.Range Height {
            get {
                return this.HeightField;
            }
            set {
                if ((object.ReferenceEquals(this.HeightField, value) != true)) {
                    this.HeightField = value;
                    this.RaisePropertyChanged("Height");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nationality {
            get {
                return this.NationalityField;
            }
            set {
                if ((object.ReferenceEquals(this.NationalityField, value) != true)) {
                    this.NationalityField = value;
                    this.RaisePropertyChanged("Nationality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.Sex Sex {
            get {
                return this.SexField;
            }
            set {
                if ((this.SexField.Equals(value) != true)) {
                    this.SexField = value;
                    this.RaisePropertyChanged("Sex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.Range Weight {
            get {
                return this.WeightField;
            }
            set {
                if ((object.ReferenceEquals(this.WeightField, value) != true)) {
                    this.WeightField = value;
                    this.RaisePropertyChanged("Weight");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Range", Namespace="http://schemas.datacontract.org/2004/07/NationalCriminal.Search.DataContracts")]
    [System.SerializableAttribute()]
    public partial class Range : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EndField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int StartField;
        
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
        public int End {
            get {
                return this.EndField;
            }
            set {
                if ((this.EndField.Equals(value) != true)) {
                    this.EndField = value;
                    this.RaisePropertyChanged("End");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Start {
            get {
                return this.StartField;
            }
            set {
                if ((this.StartField.Equals(value) != true)) {
                    this.StartField = value;
                    this.RaisePropertyChanged("Start");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Sex", Namespace="http://schemas.datacontract.org/2004/07/NationalCriminal.Search.DataContracts")]
    public enum Sex : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Male = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Female = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Other = 2,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CriminalSearchServiceReference.ICriminalSearch")]
    public interface ICriminalSearch {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICriminalSearch/Search", ReplyAction="http://tempuri.org/ICriminalSearch/SearchResponse")]
        bool Search(NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.CriminalSearchRequest searchRequest, System.Nullable<int> maxRecords, string emailId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICriminalSearch/Search", ReplyAction="http://tempuri.org/ICriminalSearch/SearchResponse")]
        System.Threading.Tasks.Task<bool> SearchAsync(NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.CriminalSearchRequest searchRequest, System.Nullable<int> maxRecords, string emailId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICriminalSearchChannel : NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.ICriminalSearch, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CriminalSearchClient : System.ServiceModel.ClientBase<NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.ICriminalSearch>, NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.ICriminalSearch {
        
        public CriminalSearchClient() {
        }
        
        public CriminalSearchClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CriminalSearchClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CriminalSearchClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CriminalSearchClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool Search(NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.CriminalSearchRequest searchRequest, System.Nullable<int> maxRecords, string emailId) {
            return base.Channel.Search(searchRequest, maxRecords, emailId);
        }
        
        public System.Threading.Tasks.Task<bool> SearchAsync(NationalCriminal.Search.Service.ServiceTests.CriminalSearchServiceReference.CriminalSearchRequest searchRequest, System.Nullable<int> maxRecords, string emailId) {
            return base.Channel.SearchAsync(searchRequest, maxRecords, emailId);
        }
    }
}
