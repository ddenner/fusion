﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FusionSoapServiceSDK.FusionSoapService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AbstractData", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Data")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.Address))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.SpatialData))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.Phone))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.PersonName))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.EmailAddress))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.ChangeInformation))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.Patient))]
    public partial class AbstractData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Address", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Data")]
    [System.SerializableAttribute()]
    public partial class Address : FusionSoapServiceSDK.FusionSoapService.AbstractData {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Address1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Address2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FusionSoapServiceSDK.FusionSoapService.SpatialData GeoLocationField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ZipCodeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address1 {
            get {
                return this.Address1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Address1Field, value) != true)) {
                    this.Address1Field = value;
                    this.RaisePropertyChanged("Address1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address2 {
            get {
                return this.Address2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Address2Field, value) != true)) {
                    this.Address2Field = value;
                    this.RaisePropertyChanged("Address2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string City {
            get {
                return this.CityField;
            }
            set {
                if ((object.ReferenceEquals(this.CityField, value) != true)) {
                    this.CityField = value;
                    this.RaisePropertyChanged("City");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FusionSoapServiceSDK.FusionSoapService.SpatialData GeoLocation {
            get {
                return this.GeoLocationField;
            }
            set {
                if ((object.ReferenceEquals(this.GeoLocationField, value) != true)) {
                    this.GeoLocationField = value;
                    this.RaisePropertyChanged("GeoLocation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string State {
            get {
                return this.StateField;
            }
            set {
                if ((object.ReferenceEquals(this.StateField, value) != true)) {
                    this.StateField = value;
                    this.RaisePropertyChanged("State");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ZipCode {
            get {
                return this.ZipCodeField;
            }
            set {
                if ((this.ZipCodeField.Equals(value) != true)) {
                    this.ZipCodeField = value;
                    this.RaisePropertyChanged("ZipCode");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SpatialData", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Data")]
    [System.SerializableAttribute()]
    public partial class SpatialData : FusionSoapServiceSDK.FusionSoapService.AbstractData {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float LatitudeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float LongitudeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Latitude {
            get {
                return this.LatitudeField;
            }
            set {
                if ((this.LatitudeField.Equals(value) != true)) {
                    this.LatitudeField = value;
                    this.RaisePropertyChanged("Latitude");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Longitude {
            get {
                return this.LongitudeField;
            }
            set {
                if ((this.LongitudeField.Equals(value) != true)) {
                    this.LongitudeField = value;
                    this.RaisePropertyChanged("Longitude");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Phone", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Data")]
    [System.SerializableAttribute()]
    public partial class Phone : FusionSoapServiceSDK.FusionSoapService.AbstractData {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NumberField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Number {
            get {
                return this.NumberField;
            }
            set {
                if ((object.ReferenceEquals(this.NumberField, value) != true)) {
                    this.NumberField = value;
                    this.RaisePropertyChanged("Number");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PersonName", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Data")]
    [System.SerializableAttribute()]
    public partial class PersonName : FusionSoapServiceSDK.FusionSoapService.AbstractData {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="EmailAddress", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Data")]
    [System.SerializableAttribute()]
    public partial class EmailAddress : FusionSoapServiceSDK.FusionSoapService.AbstractData {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string EmailField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChangeInformation", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Data")]
    [System.SerializableAttribute()]
    public partial class ChangeInformation : FusionSoapServiceSDK.FusionSoapService.AbstractData {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime InsertDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ModifiedDateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime InsertDate {
            get {
                return this.InsertDateField;
            }
            set {
                if ((this.InsertDateField.Equals(value) != true)) {
                    this.InsertDateField = value;
                    this.RaisePropertyChanged("InsertDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime ModifiedDate {
            get {
                return this.ModifiedDateField;
            }
            set {
                if ((this.ModifiedDateField.Equals(value) != true)) {
                    this.ModifiedDateField = value;
                    this.RaisePropertyChanged("ModifiedDate");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Patient", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Data")]
    [System.SerializableAttribute()]
    public partial class Patient : FusionSoapServiceSDK.FusionSoapService.AbstractData {
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FusionSoapServiceSDK.FusionSoapService.Address HomeAddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FusionSoapServiceSDK.FusionSoapService.Phone HomePhoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int KeyField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid PatientIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FusionSoapServiceSDK.FusionSoapService.PersonName PatientNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FusionSoapServiceSDK.FusionSoapService.EmailAddress PrimaryEmailField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private FusionSoapServiceSDK.FusionSoapService.ChangeInformation TrackingField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FusionSoapServiceSDK.FusionSoapService.Address HomeAddress {
            get {
                return this.HomeAddressField;
            }
            set {
                if ((object.ReferenceEquals(this.HomeAddressField, value) != true)) {
                    this.HomeAddressField = value;
                    this.RaisePropertyChanged("HomeAddress");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FusionSoapServiceSDK.FusionSoapService.Phone HomePhone {
            get {
                return this.HomePhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.HomePhoneField, value) != true)) {
                    this.HomePhoneField = value;
                    this.RaisePropertyChanged("HomePhone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Key {
            get {
                return this.KeyField;
            }
            set {
                if ((this.KeyField.Equals(value) != true)) {
                    this.KeyField = value;
                    this.RaisePropertyChanged("Key");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid PatientId {
            get {
                return this.PatientIdField;
            }
            set {
                if ((this.PatientIdField.Equals(value) != true)) {
                    this.PatientIdField = value;
                    this.RaisePropertyChanged("PatientId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FusionSoapServiceSDK.FusionSoapService.PersonName PatientName {
            get {
                return this.PatientNameField;
            }
            set {
                if ((object.ReferenceEquals(this.PatientNameField, value) != true)) {
                    this.PatientNameField = value;
                    this.RaisePropertyChanged("PatientName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FusionSoapServiceSDK.FusionSoapService.EmailAddress PrimaryEmail {
            get {
                return this.PrimaryEmailField;
            }
            set {
                if ((object.ReferenceEquals(this.PrimaryEmailField, value) != true)) {
                    this.PrimaryEmailField = value;
                    this.RaisePropertyChanged("PrimaryEmail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public FusionSoapServiceSDK.FusionSoapService.ChangeInformation Tracking {
            get {
                return this.TrackingField;
            }
            set {
                if ((object.ReferenceEquals(this.TrackingField, value) != true)) {
                    this.TrackingField = value;
                    this.RaisePropertyChanged("Tracking");
                }
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FusionServicesException", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Exceptions")]
    [System.SerializableAttribute()]
    public partial class FusionServicesException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StackTraceField;
        
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
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StackTrace {
            get {
                return this.StackTraceField;
            }
            set {
                if ((object.ReferenceEquals(this.StackTraceField, value) != true)) {
                    this.StackTraceField = value;
                    this.RaisePropertyChanged("StackTrace");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://dougfusion.com", ConfigurationName="FusionSoapService.IFusionService")]
    public interface IFusionService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dougfusion.com/IFusionService/InsertUpdatePatient", ReplyAction="http://dougfusion.com/IFusionService/InsertUpdatePatientResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.FusionServicesException), Action="http://dougfusion.com/IFusionService/InsertUpdatePatientFusionServicesExceptionFa" +
            "ult", Name="FusionServicesException", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Exceptions")]
        void InsertUpdatePatient(FusionSoapServiceSDK.FusionSoapService.Patient patient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dougfusion.com/IFusionService/InsertUpdatePatient", ReplyAction="http://dougfusion.com/IFusionService/InsertUpdatePatientResponse")]
        System.Threading.Tasks.Task InsertUpdatePatientAsync(FusionSoapServiceSDK.FusionSoapService.Patient patient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dougfusion.com/IFusionService/GetPatient", ReplyAction="http://dougfusion.com/IFusionService/GetPatientResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(FusionSoapServiceSDK.FusionSoapService.FusionServicesException), Action="http://dougfusion.com/IFusionService/GetPatientFusionServicesExceptionFault", Name="FusionServicesException", Namespace="http://schemas.datacontract.org/2004/07/FusionSoapService.Contracts.Exceptions")]
        FusionSoapServiceSDK.FusionSoapService.Patient GetPatient(System.Guid patientId, int region);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://dougfusion.com/IFusionService/GetPatient", ReplyAction="http://dougfusion.com/IFusionService/GetPatientResponse")]
        System.Threading.Tasks.Task<FusionSoapServiceSDK.FusionSoapService.Patient> GetPatientAsync(System.Guid patientId, int region);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IFusionServiceChannel : FusionSoapServiceSDK.FusionSoapService.IFusionService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FusionServiceClient : System.ServiceModel.ClientBase<FusionSoapServiceSDK.FusionSoapService.IFusionService>, FusionSoapServiceSDK.FusionSoapService.IFusionService {
        
        public FusionServiceClient() {
        }
        
        public FusionServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FusionServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FusionServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FusionServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void InsertUpdatePatient(FusionSoapServiceSDK.FusionSoapService.Patient patient) {
            base.Channel.InsertUpdatePatient(patient);
        }
        
        public System.Threading.Tasks.Task InsertUpdatePatientAsync(FusionSoapServiceSDK.FusionSoapService.Patient patient) {
            return base.Channel.InsertUpdatePatientAsync(patient);
        }
        
        public FusionSoapServiceSDK.FusionSoapService.Patient GetPatient(System.Guid patientId, int region) {
            return base.Channel.GetPatient(patientId, region);
        }
        
        public System.Threading.Tasks.Task<FusionSoapServiceSDK.FusionSoapService.Patient> GetPatientAsync(System.Guid patientId, int region) {
            return base.Channel.GetPatientAsync(patientId, region);
        }
    }
}
