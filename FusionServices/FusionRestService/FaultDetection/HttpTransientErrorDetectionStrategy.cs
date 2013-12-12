using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace FusionRestService.FaultDetection
{
    // http://alexandrebrisebois.wordpress.com/2013/02/21/defining-an-http-transient-error-detection-strategy-for-rest-calls/
    public class HttpTransientErrorDetectionStrategy
        : ITransientErrorDetectionStrategy
    {
        private readonly List<HttpStatusCode> _statusCodes =
            new List<HttpStatusCode>
        {
            HttpStatusCode.GatewayTimeout,
            HttpStatusCode.RequestTimeout,
            HttpStatusCode.ServiceUnavailable,
        };

        public HttpTransientErrorDetectionStrategy(bool isNotFoundAsTransient = false)
        {
            if (isNotFoundAsTransient)
                _statusCodes.Add(HttpStatusCode.NotFound);
        }

        public bool IsTransient(Exception ex)
        {
            var we = ex as WebException;
            if (we == null)
                return false;

            var response = we.Response as HttpWebResponse;

            var isTransient = response != null
                                       && _statusCodes.Contains(response.StatusCode);
            return isTransient;
        }
    }
}