using System;
using System.Diagnostics.Tracing;

namespace FusionSoapService.Logging
{
    public class FusionServiceEventSource : EventSource
    {
        private static readonly Lazy<FusionServiceEventSource> Instance = new Lazy<FusionServiceEventSource>(() => new FusionServiceEventSource());

        private FusionServiceEventSource()
        {
        }

        public static FusionServiceEventSource Log
        {
            get { return Instance.Value; }
        }

        [Event(1, Message = "Log: {0} in {1} milliseconds.", Level = EventLevel.Informational)]
        public void OnSuccess(String serializeObject, String callTime)
        {
            this.WriteEvent(1, serializeObject, callTime);
        }

        [Event(2, Message = "Log: {0} {1} {2} milliseconds.", Level = EventLevel.Error)]
        public void OnFailure(String error, String serializeObject, String callTime)
        {
            this.WriteEvent(2, serializeObject, error, callTime);
        }

    }
}