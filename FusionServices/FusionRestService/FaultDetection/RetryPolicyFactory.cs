using System;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace FusionRestService.FaultDetection
{
    // http://alexandrebrisebois.wordpress.com/2013/02/21/defining-an-http-transient-error-detection-strategy-for-rest-calls/
    public static class RetryPolicyFactory
    {
        public static RetryPolicy MakeHttpRetryPolicy(int count = 2,
                                                      bool notFoundIsTransient = false)
        {
            var strategy = new HttpTransientErrorDetectionStrategy(notFoundIsTransient);
            return Exponential(strategy, count);
        }

        private static RetryPolicy Exponential(ITransientErrorDetectionStrategy stgy,
                                                int retryCount = 2,
                                                double maxBackoffDelayInSeconds = 2,
                                                double delta = 2)
        {
            var maxBackoff = TimeSpan.FromSeconds(maxBackoffDelayInSeconds);
            var deltaBackoff = TimeSpan.FromSeconds(delta);
            var minBackoff = TimeSpan.FromSeconds(0);

            var exponentialBackoff = new ExponentialBackoff(retryCount,
                                                            minBackoff,
                                                            maxBackoff,
                                                            deltaBackoff);
            return new RetryPolicy(stgy, exponentialBackoff);
        }
    }
}