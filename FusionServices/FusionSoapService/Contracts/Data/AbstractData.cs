using System;
using System.Data;
using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace FusionSoapService.Contracts.Data
{
    /// <summary>
    /// Base class that all data objects inherit from.  Currently makes sure all unknown properties don't get lost
    /// </summary>
    [DataContract(Namespace = @"http://dougfusion.com")]
    public abstract class AbstractData : IExtensibleDataObject
    {
        public ExtensionDataObject ExtensionData { get; set; }

    }
}
