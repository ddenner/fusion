using System;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.ServiceModel;
using FusionSoapService.Contracts.Data;
using FusionSoapService.Contracts.Exceptions;
using FusionSoapService.DataSource;
using FusionSoapService.Logging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging;
using Microsoft.Practices.EnterpriseLibrary.SemanticLogging.Sinks;

namespace FusionSoapService
{
    /// <summary>
    /// Main service implementation.
    /// </summary>
    public class FusionService : IFusionService, IDisposable
    {
        private ObservableEventListener _listener = null;
        private SinkSubscription<RollingFlatFileSink> _logToRollingSubscription = null;

        public FusionService()
        {
            SetupFileLog();
        }

        private void SetupFileLog()
        {
            _listener = new ObservableEventListener();

            _logToRollingSubscription = _listener.LogToRollingFlatFile((string)ConfigurationManager.AppSettings["FileTrace"],
                                                                     1024,
                                                                     "ddmmyy",
                                                                     RollFileExistsBehavior.Increment,
                                                                     RollInterval.Midnight);

            _listener.EnableEvents(FusionServiceEventSource.Log, EventLevel.LogAlways);
        }

        private string GetMessage(Exception ex)
        {
            return ex.Message + (ex.InnerException != null ? string.Format("\n\n----------------------------------\n\n{0}", GetMessage(ex.InnerException)) : string.Empty);
        }

        private string GetStackTrace(Exception ex)
        {
            return ex.StackTrace + (ex.InnerException != null ? string.Format("\n\n----------------------------------\n\n{0}", GetStackTrace(ex.InnerException)) : string.Empty);
        }

        public void InsertUpdatePatient(Patient patient)
        {
            DateTime utcNow = DateTime.UtcNow;

            try
            {
                using (var patientMapper = new PatientMapper())
                {
                    patientMapper.InsertUpdatePatient(patient);
                }

                FusionServiceEventSource.Log.OnSuccess(patient.ToString(), (DateTime.UtcNow - utcNow).TotalMilliseconds.ToString());
            }
            catch (Exception e)
            {
                FusionServiceEventSource.Log.OnFailure(GetMessage(e), patient.ToString(), (DateTime.UtcNow - utcNow).TotalMilliseconds.ToString());
                throw new FaultException<FusionServicesException>(new FusionServicesException() { Message = GetMessage(e), StackTrace = GetStackTrace(e) }, new FaultReason(e.Message));
            }            
        }

        public Contracts.Data.Patient GetPatient(Guid patientId, int region)
        {
            DateTime utcNow = DateTime.UtcNow;

            try
            {
                using (var patientMapper = new PatientMapper())
                {
                    var patient = patientMapper.GetPatient(patientId, region);
                    FusionServiceEventSource.Log.OnSuccess(patient.ToString(), (DateTime.UtcNow - utcNow).TotalMilliseconds.ToString());
                    return patient;
                }
            }
            catch (Exception e)
            {
                FusionServiceEventSource.Log.OnFailure(GetMessage(e), patientId.ToString(), (DateTime.UtcNow - utcNow).TotalMilliseconds.ToString());
                throw new FaultException<FusionServicesException>(
                    new FusionServicesException() {Message = GetMessage(e), StackTrace = GetStackTrace(e)},
                    new FaultReason(e.Message));
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _logToRollingSubscription.Sink.FlushAsync();
                    _logToRollingSubscription.Dispose();
                    
                    //  Code that runs on application shutdown
                    _listener.DisableEvents(FusionServiceEventSource.Log);
                    _listener.Dispose();
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
            _disposed = true;
        }
    }
}
